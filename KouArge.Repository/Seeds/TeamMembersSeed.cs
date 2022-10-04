using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace KouArge.Repository.Seeds
{
    public class TeamMembersSeed : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.HasData(new TeamMember()
            {
                Id = 1,
                TeamId = 1,
                GeneralAssemblyId = 1,
                CreatedAt = DateTime.Now,
                Title = "titleTeamMember",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Teams = { new Team()
                {
                    Id = 1,
                    Name = "Webino",
                    CreatedAt = DateTime.Now,
                    Description = "Webino Takımı",
                    teamMembers = new List<TeamMember>() { new TeamMember() { CreatedAt = DateTime.Now, Id = 1, TeamId = 1, } },
                    LogoUrl = "logoUrl",
                }},
                GeneralAssemblies = { new GeneralAssembly() }

            });
        }
    }
}
