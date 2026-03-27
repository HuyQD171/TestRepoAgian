using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.User;

public class Service : IService
{
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreateUser(Request.UserRequest request)
    {
        var existingUser = _dbContext.Users.Where(
            x => x.Email == request.Email);

        bool IsExistingUser = await existingUser.AnyAsync();

        if (IsExistingUser)
        {
            throw new Exception("Email already exists");
        }

        var newUser = new Repository.Entity.User()
        {
            Email = request.Email,
            Password =  request.Password,
        };

        _dbContext.Add(newUser);
        await _dbContext.SaveChangesAsync();
        
        return "Create usser successful";
    }

    public async Task<Base.Response.PageRerults<Response.GetUserResponse>> GetAllUsers(string? searchTerm, int pageIndex,
        int pageSize)
    {
        var query = _dbContext.Users.Where(x => true);

        query = query.OrderBy(x => x.Email);

        query = query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);
        
        var SelectQuery = query.Select(x => new Response.GetUserResponse()
        {
            Email =  x.Email,
            Password = x.Password,
            Role =  x.Role,
        });
        
        var ListResults = await SelectQuery.ToListAsync();
        var totalItems = ListResults.Count;

        var results = new Base.Response.PageRerults<Response.GetUserResponse>()
        {
            Items = ListResults,
            Totalitem = totalItems,
            PageSize = pageSize,
            PageIndex = pageIndex,
        };
        return results;
    }
}