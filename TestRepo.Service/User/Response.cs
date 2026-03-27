namespace TetPee.Service.User;

public class Response
{
    public class GetUserResponse
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}