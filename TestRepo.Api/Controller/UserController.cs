

using Microsoft.AspNetCore.Mvc;
using TetPee.Repository;
using TetPee.Service.User;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    
    private readonly AppDbContext _dbContext;
    private readonly IService _service;

    public UserController(AppDbContext dbContext, IService service)
    {
        _dbContext = dbContext;
        _service = service;
    }

    [HttpPost("")]
    public async Task<IActionResult> GetUsers(Request.UserRequest request)
    {
        var rs = await _service.CreateUser(request);
        return Ok(rs);
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetUsers([FromQuery] string? searchTerm, int pageSize = 3, int pageIndex = 1)
    {
        
        var users = await _service.GetAllUsers(searchTerm, pageSize, pageIndex);
 
        // throw new Exception("Get Users Error");
        return Ok(users);
    }
}