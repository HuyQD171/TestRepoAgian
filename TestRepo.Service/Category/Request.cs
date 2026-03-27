namespace TetPee.Service.Category;

public class Request
{
    public class CategoryRequest
    {
        public string name { get; set; }

        public Guid? ParentId { get; set; }

    }
}