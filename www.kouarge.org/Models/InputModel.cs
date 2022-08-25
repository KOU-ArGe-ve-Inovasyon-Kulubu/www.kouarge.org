using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace www.kouarge.org.Models
{
    public class InputModel
    {

        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
