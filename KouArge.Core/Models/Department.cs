namespace KouArge.Core.Models
{
    public class Department : StringBaseEntity
    {
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
