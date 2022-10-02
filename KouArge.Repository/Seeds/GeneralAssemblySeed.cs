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
                 CreatedAt = DateTime.Now,
                 Id=1,
            });
        }
    }
}
