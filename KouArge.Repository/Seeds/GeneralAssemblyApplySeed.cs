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
    public class GeneralAssemblyApplySeed : IEntityTypeConfiguration<GeneralAssemblyApply>
    {
        public void Configure(EntityTypeBuilder<GeneralAssemblyApply> builder)
        {
            builder.HasData(new GeneralAssemblyApply()
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                TeamId = 1,
                Introducing = "Introducing",
                ApplyTime = "ApplyTime",
                SituationDescription = "SituationDescription",
                Staus = 200,
                UserId = "1",
                Why="why"
                

            });
        }
    }
}
