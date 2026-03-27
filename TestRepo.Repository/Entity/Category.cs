using TetPee.Repository.Abstraction;

namespace TetPee.Repository.Entity;

public class Category : BaseEntity<Guid>, IAuditablrEntity
{
    public string name { get; set; }
    public Guid? ParentId { get; set; }
    public Category? Parent { get; set; }
    
    public  ICollection<Category> Children { get; set; } = new List<Category>();
    
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}