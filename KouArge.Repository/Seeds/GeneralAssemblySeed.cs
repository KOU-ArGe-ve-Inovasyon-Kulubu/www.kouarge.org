using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Repository.Seeds
{
    public class GeneralAssemblySeed : IEntityTypeConfiguration<GeneralAssembly>
    {
        public void Configure(EntityTypeBuilder<GeneralAssembly> builder)
        {
            builder.HasData(new GeneralAssembly() 
            {
                User = new AppUser(),
                Id = 1,
                CreatedAt = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                PıctureUrl = "pictureUrl",
                Teams = { new Team()
                {
                    Id = 1,
                    Name = "Webino",
                    CreatedAt = DateTime.Now,
                    Description = "Webino Takımı",
                    teamMembers = new List<TeamMember>() { new TeamMember() { CreatedAt = DateTime.Now, Id = 1, TeamId = 1, } },
                    LogoUrl = "logoUrl",
                }},
                Status=200,
                //TeamMembers = { new TeamMember() { } },
                UserId="1",
                
            });
        }
    }
}
