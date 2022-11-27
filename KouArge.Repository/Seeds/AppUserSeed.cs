using KouArge.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Seeds
{
    public class AppUserSeed : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var hasher = new PasswordHasher<AppUser>();

            var appUser = new AppUser()
            {
                Id = "1",
                Name = "test",
                DepartmentId = "1",
                Email = "test@gmail.com",
                IsActive = true,
                StudentNumber = "191307000",
                PhoneNumber = "5303003030",
                UserName = "1",
                Surname = "test",
                CreatedAt = DateTime.Now,
                NotificationId = 1,
                Year = 2,
                NormalizedUserName = "1",
                NormalizedEmail = "TEST@GMAIL.COM",
            };
            appUser.PasswordHash = hasher.HashPassword(appUser, "Aa123456*");

            var appUser2 = new AppUser()
            {
                Id = "2",
                Name = "test2",
                DepartmentId = "1",
                Email = "test2@gmail.com",
                IsActive = true,
                StudentNumber = "191307001",
                PhoneNumber = "5303003031",
                UserName = "2",
                Surname = "test2",
                CreatedAt = DateTime.Now,
                NotificationId = 1,
                Year = 2,
                NormalizedUserName = "2",
                NormalizedEmail = "TEST2@GMAIL.COM",
            };
            appUser.PasswordHash = hasher.HashPassword(appUser, "Aa123456*");



            builder.HasData(appUser);
            builder.HasData(appUser2);


        }
    }
}
