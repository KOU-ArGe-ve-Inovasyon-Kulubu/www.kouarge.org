using Microsoft.AspNetCore.Identity;

namespace KouArge.Core.Models
{
    public class AppUser : IdentityUser
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNumber { get; set; }

        //public string FacultyId { get; set; }
        public string DepartmentId { get; set; }
        public int Year { get; set; }//sınıf
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public int NotificationId { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpires { get; set; }

        public Notification Notification { get; set; }
        public Department Department { get; set; }
        //public GeneralAssembly GeneralAssembly { get; set; }

        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<EventParticipant> EventParticipantLists { get; set; }
        public ICollection<GeneralAssemblyApply> GeneralAssemblyApplyies { get; set; }



    }
}
