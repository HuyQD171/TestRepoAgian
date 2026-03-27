using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TetPee.Repository;
using TetPee.Service.Category;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IService _service;

    public CategoryController(AppDbContext dbContext, IService service)
    {
        _dbContext = dbContext;
        _service = service;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateCategory(Request.CategoryRequest request)
    {
        try
        {
            var results = await _service.CreateCateTask(request);
            return Ok(results);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("")]
    public async Task<IActionResult> GetCategories()
    {
        var results = await _service.GetAllCategoryResponse();
        return Ok(results);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoriesById(Guid id)
    {
        var results = await _service.GetCategoryByIdResponse(id);
        return Ok(results);
    }
}