using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KouArge.Core.DTOs.ViewModel
{
    public class AppUserUpdateViewModel
    {
        public string Id { get; set; }

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
        public bool IsActive { get; set; } = true;
        public int NotificationId { get; set; }
        public DepartmentDto Department { get; set; }
        public FacultyDto Faculty { get; set; }
    }
}
