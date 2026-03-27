namespace TetPee.Service.Category;

public interface IService
{
    public Task<string> CreateCateTask(Request.CategoryRequest request);
}