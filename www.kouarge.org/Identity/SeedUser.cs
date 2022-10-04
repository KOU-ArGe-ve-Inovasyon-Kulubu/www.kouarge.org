using KouArge.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace www.kouarge.org.Identity
{
    public class SeedUser
    {

        public static async void AddUser(IServiceProvider serviceProvider)
        {   

            var userManager = serviceProvider.GetService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

           
            if (await userManager.FindByEmailAsync("admin@kouarege.org") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("Iletisim"));
                await roleManager.CreateAsync(new IdentityRole("Tasarim"));
                await roleManager.CreateAsync(new IdentityRole("Etkinlik"));
                await roleManager.CreateAsync(new IdentityRole("SosyalMedya"));
                await roleManager.CreateAsync(new IdentityRole("Webino"));

                var adminUser = new AppUser
                {
                    Name = "Admin",
                    Surname = "-",
                    Email = "admin@kouarege.org",
                    EmailConfirmed = true,
                    UserName = "Admin",
                    PhoneNumber = "5555 55 55555",
                    //FacultyID = "-",
                    DepartmentId = 1,
                    StudentNo = "-"
                };

                var result = await userManager.CreateAsync(adminUser, "Aasfa124f*");
                
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
               
            }
        }
    }
}
