using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using www.kouarge.org.Identity;

namespace www.kouarge.org.Pages.Admin
{
    public class UsersModel : PageModel
    {     
        //public List<string> sayýlar = new List<string>() {"1","2","3","4" };
        public AppIdentityDbContext app1 { get; set; }

        public int usernumber;
        public void OnGet()
        {
            //app1.Users.Count();
            //sayýlar[0] = "musti";
        }
    }
}
