
using KouArge.Core.DTOs;
using Microsoft.AspNetCore.Identity;

namespace KouArge.Core.Models
{
    public class AppUser : IdentityUser
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNo { get; set; }

        //public string FacultyId { get; set; }
        public int DepartmentId { get; set; }
        public int Year { get; set; }//sınıf
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Status { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpires { get; set; }

        public Department Department { get; set; }
        public GeneralAssembly GeneralAssembly { get; set; }
        public ICollection<EventParticipant> EventParticipantLists { get; set; }
        public ICollection<GeneralAssemblyApply> GeneralAssemblyApplys { get; set; }

    }
}
