using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Seeds
{
    public class TitleSeed : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {

            builder.HasData(new Title()
            {
                Id = 1,
                Name = "Takım Kaptanı",
                IsActive = true,
                CreatedAt = DateTime.Now,

            },
            new Title()
            {
                Id = 2,
                Name = "Takım Kaptan Yardımcısı",
                IsActive = true,
                CreatedAt = DateTime.Now,

            },
            new Title()
            {
                Id = 3,
                Name = "Takım Üyesi",
                IsActive = true,
                CreatedAt = DateTime.Now,
            });

        }
    }
}
