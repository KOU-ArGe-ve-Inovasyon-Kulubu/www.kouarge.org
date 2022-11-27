using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                TitleId = 1,
                Introducing = "Introducing",
                ApplyTime = DateTime.Now,
                SituationDescription = "SituationDescription",
                AppStatus = 0,
                IsActive = true,
                AppUserId = "1",
                Why = "why"
            },
            new GeneralAssemblyApply()
            {
                Id = 2,
                CreatedAt = DateTime.Now,
                TeamId = 1,
                TitleId = 2,
                Introducing = "Introducing2",
                ApplyTime = DateTime.Now,
                SituationDescription = "SituationDescription2",
                AppStatus = 1,
                IsActive = true,
                AppUserId = "1",
                Why = "why2"
            });
        }
    }
}
