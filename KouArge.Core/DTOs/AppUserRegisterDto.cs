using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class AppUserRegisterDto
    {
        [Display(Name = "Ad:")]
        public string Name { get; set; }
        [Display(Name = "Soyad:")]
        public string Surname { get; set; }
        [Display(Name = "Öğrenci Numarası:")]
        public string StudentNo { get; set; }
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
        public int DepartmentId { get; set; }

        [Display(Name = "Sınıf:")]
        public int Year { get; set; }

        [Display(Name = "KVKK")]
        public bool KVKK { get; set; }
        public bool NotificationId { get; set; } = true;
        public int Status { get; set; }

        [JsonIgnore]
        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int ErrorStatus { get; set; }

    }
}
