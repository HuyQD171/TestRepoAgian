using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.Seller;

public class Service : IService
{
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreateSeller(Request.SellerRequest request)
    {
        var existing =
            _dbContext.Users.Where(x => x.Email == request.Email);
        
        
        bool IsExistingUser = await existing.AnyAsync();

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

        var result = await _dbContext.SaveChangesAsync();
        
        if (result > 0)
        {
            var seller = new Repository.Entity.Seller()
            {
                CompanyAddress = request.CompanyAddress,
                CompanyName = request.CompanyName,
                TaxCode = request.TaxCode,
                UserId = newUser.Id,
            };
            
            _dbContext.Add(seller);
            
            var sellerResult = await _dbContext.SaveChangesAsync();

            if (sellerResult > 0) return "Add Seller successfully";
            
            return "FailToAddSeller";
        }
        
        return "FailToAddSeller";

        
    }
}