using TetPee.Repository.Abstraction;

namespace TetPee.Repository.Entity;

public class Product : BaseEntity<Guid>, IAuditablrEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    
    public Guid SellerId { get; set; }
    public Seller? Seller { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}