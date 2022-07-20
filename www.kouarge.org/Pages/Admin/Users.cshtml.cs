using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using www.kouarge.org.Identity;

namespace www.kouarge.org.Pages.Admin
{
    public class UsersModel : PageModel
    {
        private readonly AppIdentityDbContext _app1 ;
        public IEnumerable<AppUser> Users { get; set; }

        #region
        //public IEnumerable<IdentityUserRole<string>> UserRole { get; set; }
        //public IEnumerable<IdentityRole<string>> Roles { get; set; }
        //public string userrolename { get; set; }
        #endregion

        public UsersModel(AppIdentityDbContext app1)
        {
            _app1=app1 ;  
        }

        public void OnGet()
        {
            Users = _app1.Users;
            //UserRole = _app1.UserRoles;
            //Roles = _app1.Roles;
        }
    
    }
}
