using Microsoft.AspNetCore.Identity;

namespace www.kouarge.org.Identity
{
    public class AppUserServiceImpl : AppUserService
    {

        private UserManager<AppUser> _appUsers;
        public AppUserServiceImpl(UserManager<AppUser> appUsers)
        {
            _appUsers = appUsers;
        }
        public AppUser Login(string userName, string password)
        {
            return _appUsers.Users.FirstOrDefault(x => x.UserName == userName && x.PasswordHash == password);
        }
    }
}
