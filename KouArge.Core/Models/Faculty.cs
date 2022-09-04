namespace KouArge.Core.Models
{
    public class Faculty:BaseEntity
    {
        public string Name { get; set; }
        public string Campus { get; set; }
        public ICollection<Department> Departments { get; set; }

    }
}
