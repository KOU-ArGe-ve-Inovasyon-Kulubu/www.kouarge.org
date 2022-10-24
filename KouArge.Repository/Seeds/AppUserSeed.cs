using KouArge.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Repository.Seeds
{
    public class AppUserSeed : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(new AppUser()
            {
                Id = "1",
                Name = "test",
                DepartmentId = "1",
                Email = "test@gmail.com",
                Status = 1,
                StudentNo = "1",
                UserName = "1",
                PasswordHash = "asd",
                Surname = "test",
                CreatedAt = DateTime.Now,
                NotificationId=1,
                Year=2
                
            });

        }
    }
}
