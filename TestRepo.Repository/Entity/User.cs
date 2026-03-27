using TetPee.Repository.Abstraction;

namespace TetPee.Repository.Entity;

public class User : BaseEntity<Guid>, IAuditablrEntity
{
    public required string Password { get; set; }
    public required string Email { get; set; }
    public string Role { get; set; } = "User";
    
    public Seller? Seller { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}