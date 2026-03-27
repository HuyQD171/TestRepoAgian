using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.Category;

public class Service : IService
{
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreateCateTask(Request.CategoryRequest request)
    {
        var exsitingCateQuery =
            _dbContext.Categories.Where(x => x.name.ToLower().Trim() == request.name.ToLower().Trim());

        bool isExistingCate = await exsitingCateQuery.AnyAsync();

        if (isExistingCate)
        {
            throw new Exception("Name already exists");
        }
        
        if (request.ParentId != null)
        {
            var existingParentIdQuery =
                _dbContext.Categories.Where(x => x.Id == request.ParentId);
            
            bool isExistingParentId = await existingParentIdQuery.AnyAsync();

            if (!isExistingParentId)
            {
                throw new Exception("ParentId does not exist");
            }
        }
        
        var newCate = new Repository.Entity.Category()
        {
            name = request.name,
            ParentId = request.ParentId
        };

        _dbContext.Add(newCate);
        await _dbContext.SaveChangesAsync();
        
        return "Create successful";

    }
}