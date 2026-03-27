using TetPee.Repository.Abstraction;

namespace TetPee.Repository.Entity;

public class Seller : BaseEntity<Guid>, IAuditablrEntity
{
    public  string TaxCode { get; set; }
    public string CompanyAddress { get; set; }
    public string CompanyName { get; set; } = "User";
    
    public Guid UserId { get; set; }
    public User User { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
    
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}