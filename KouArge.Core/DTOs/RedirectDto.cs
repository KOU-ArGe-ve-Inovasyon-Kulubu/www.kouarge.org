using KouArge.Core.Models;

namespace KouArge.Core.DTOs
{
    public class RedirectDto : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public int Count { get; set; }
    }
}
