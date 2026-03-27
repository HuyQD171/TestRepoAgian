namespace TetPee.Repository.Abstraction;

public interface IAuditablrEntity
{
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}