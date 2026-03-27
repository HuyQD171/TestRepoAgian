namespace TetPee.Service.Category;

public interface IService
{
    public Task<string> CreateCateTask(Request.CategoryRequest request);
    
    public Task<List<Response.CategoryResponse>> GetAllCategoryResponse();
    
    public Task<List<Response.CategoryResponse>> GetCategoryByIdResponse(Guid id);
}