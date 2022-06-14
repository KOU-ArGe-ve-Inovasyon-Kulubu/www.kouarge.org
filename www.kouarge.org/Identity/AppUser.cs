using Microsoft.AspNetCore.Identity;

namespace www.kouarge.org.Identity
{
    public class AppUser: IdentityUser
    {
        public string Name { get; set;}
        public string Surname { get; set; }
        public string StudentNo { get; set; }
        public string FacultyID { get; set; }
        
        public string DepartmentID { get; set; }
        public byte Year { get; set; }
        public DateTime Date { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
