using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using www.kouarge.org.Identity;

namespace www.kouarge.org.Pages.Admin
{
    //Sadece admin rolüne sahip kiþiler bu sayfaya eriþebilir 
    [Authorize(Roles ="Admin")]
    public class RolesModel : PageModel
    {
        private readonly AppIdentityDbContext _app1;
        public IEnumerable<IdentityRole<string>> Roles { get; set; }
        public RolesModel(AppIdentityDbContext app1)
        {
            _app1=app1;
        }
        public void OnGet()
        {
            Roles = _app1.Roles;
        }
    }
}
