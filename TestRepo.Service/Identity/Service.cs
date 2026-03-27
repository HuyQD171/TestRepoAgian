using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TetPee.Repository;
using TetPee.Service.JwtService;

namespace TetPee.Service.Identity;

public class Service : IService
{
    private readonly JwtOptions _jwtOption = new();
    private readonly AppDbContext _dbContext;
    private readonly JwtService.IService _Jwtservice;

    public Service(AppDbContext dbContext, JwtService.IService jwtservice, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _Jwtservice = jwtservice;
        configuration.GetSection(nameof(JwtOptions)).Bind(_jwtOption);
    }
    
    public async Task<Response.IdentityResponse> Login(string email, string password)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (user.Password != password)
        {
            throw new Exception("Wrong password");
        }

        var claim = new List<Claim>()
        {
            new Claim("Role", user.Role),
            new Claim("email", user.Email),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Expired,
                DateTimeOffset.UtcNow.AddMinutes(_jwtOption.ExpireMinutes).ToString()),
        };
        
        var token = _Jwtservice.GenerateAccessToken(claim);

        var rs = new Response.IdentityResponse()
        {
            AccessToken = token,
        };

        return rs;
    }
}