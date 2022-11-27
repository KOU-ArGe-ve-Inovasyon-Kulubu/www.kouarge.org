using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KouArge.Core.DTOs
{
    public class AppUserRegisterDto
    {
        [Display(Name = "Ad:")]
        public string Name { get; set; }
        [Display(Name = "Soyad:")]
        public string Surname { get; set; }
        [Display(Name = "Öğrenci Numarası:")]
        public string StudentNumber { get; set; }
        [Display(Name = "Telefon Numarası:")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Mail Adresi:")]
        public string Email { get; set; }

        [Display(Name = "Şifre:")]
        public string Password { get; set; }

        [JsonIgnore]

        [Display(Name = "Fakülte:")]
        public int FacultyId { get; set; }

        [Display(Name = "Bölüm:")]
        public string DepartmentId { get; set; }

        [Display(Name = "Sınıf:")]
        public int Year { get; set; }

        [Display(Name = "KVKK")]
        public bool KVKK { get; set; }
        public bool NotificationId { get; set; } = true;
        public bool IsActive { get; set; }

        [JsonIgnore]
        public List<ErrorViewModel> Errors { get; set; }

        //[JsonIgnore]
        //public int ErrorStatus { get; set; }

    }
}
