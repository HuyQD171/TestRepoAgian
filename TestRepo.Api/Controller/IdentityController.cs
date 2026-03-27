using Microsoft.AspNetCore.Mvc;
using TetPee.Repository;
using TetPee.Service.Identity;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class IdentityController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IService _service;

    public IdentityController(AppDbContext dbContext, IService service)
    {
        _dbContext = dbContext;
        _service = service; 
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetCategories(string email,  string password)
    {
        var results = await _service.Login(email, password);
        return Ok(results);
    }
}