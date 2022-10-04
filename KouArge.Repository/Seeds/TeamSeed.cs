using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Repository.Seeds
{
    public class TeamSeed : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(new Team()
            {
                Id = 1,
                Name = "Webino",
                CreatedAt = DateTime.Now,
                Description = "Webino Takımı",
                teamMembers = new List<TeamMember>() { new TeamMember() 
                {
                    CreatedAt = DateTime.Now,
                    Id = 1,
                    TeamId = 1,
                    StartDate = DateTime.Now,
                    EndDate= DateTime.Now,
                    Teams = new List<Team>(),
                    GeneralAssemblyId = 1,
                    GeneralAssemblies={new GeneralAssembly() },
                    Title="title"
                    
                } },
                LogoUrl = "logoUrl",

            });
        }
    }
}
