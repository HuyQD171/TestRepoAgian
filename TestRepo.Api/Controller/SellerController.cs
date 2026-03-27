using Microsoft.AspNetCore.Mvc;
using TetPee.Repository;
using TetPee.Service.Seller;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class SellerController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IService _sellerService;

    public SellerController(AppDbContext dbContext, IService sellerService)
    {
        _dbContext = dbContext;
        _sellerService = sellerService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateSeller(Request.SellerRequest request)
    {
        try
        {
            var result = await _sellerService.CreateSeller(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}