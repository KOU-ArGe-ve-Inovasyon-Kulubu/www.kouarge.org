using Microsoft.AspNetCore.Identity;

namespace www.kouarge.org.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
