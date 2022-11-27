namespace KouArge.Core.Models
{
    public class Redirect : BaseEntity
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public string Url { get; set; }
        //public int Status { get; set; }
    }
}
