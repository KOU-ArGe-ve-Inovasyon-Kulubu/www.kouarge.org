using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using www.kouarge.org.Identity;
using www.kouarge.org.Models;

namespace www.kouarge.org.Pages
{
    public class LoginModel : PageModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        public UserManager<AppUser> AppUsers { get; set; }
        public AppUser AppUser { get; set; }
        //public DbSet<AppUser> AppUsers;
        public AppIdentityDbContext _db { get; set; }
        public LoginModel(UserManager<AppUser> appUsers, AppIdentityDbContext db)
        {
            AppUsers = appUsers;
            _db =db;
        }
        public void OnGet()
        {
          
        }

        public IActionResult OnPost(string name,string passwordhash)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var user = await AppUsers.FindByNameAsync(Name);
            var user = _db.Users.FirstOrDefault(x => x.Name == name && x.PasswordHash == passwordhash);
            if (user != null)
            {

                //IdentityUserLogin<string> userLogin = new IdentityUserLogin<string>() { UserId = user.Id };
                //_db.UserLogins.Add(userLogin);
                //_db.SaveChanges();
                
                return RedirectToPage("Index");

            }

            ModelState.AddModelError("", "Bu kullanýcý adý ile daha önce hesap oluþturulmamýþ");
            return Page();
        }

    }
}
