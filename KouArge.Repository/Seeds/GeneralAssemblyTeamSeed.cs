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
    public class GeneralAssemblyTeamSeed : IEntityTypeConfiguration<GeneralAssemblyTeam>
    {
        public void Configure(EntityTypeBuilder<GeneralAssemblyTeam> builder)
        {
            builder.HasData(new GeneralAssemblyTeam() 
            {
                Id=1,
                CreatedAt=DateTime.Now,
                GeneralAssembly=new GeneralAssembly(),
                GeneralAssemblyId=1,
                TeamId=1,
                Team=new Team()
            });
        }
    }
}
