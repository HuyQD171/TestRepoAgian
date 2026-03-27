namespace TetPee.Service.Base;

public class Response
{
    public class PageRerults<item>
    {
        public List<item> Items { get; set; }
        public int Totalitem { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}