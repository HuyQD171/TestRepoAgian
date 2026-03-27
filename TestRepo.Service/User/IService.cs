namespace TetPee.Service.User;

public interface IService
{
    public Task<string> CreateUser(Request.UserRequest request);
    
    public Task<Base.Response.PageRerults<Response.GetUserResponse>> GetAllUsers(string? searchTerm, int pageIndex, int pageSize);
}