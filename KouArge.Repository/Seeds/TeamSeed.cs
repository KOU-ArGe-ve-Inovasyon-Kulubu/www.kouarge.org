using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                ImgUrl = "logoUrl",
                IsActive = true,
            },
            new Team()
            {
                Id = 2,
                Name = "Mobil",
                CreatedAt = DateTime.Now,
                Description = "Mobil Takımı",
                ImgUrl = "logoUrl2",
                IsActive = true,
            }
            );
        }
    }
}
