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

        public UsersModel(AppIdentityDbContext app1)
        {
            _app1=app1 ;  
        }

        public void OnGet()
        {
            Users = _app1.Users;

        }   
    }
}
