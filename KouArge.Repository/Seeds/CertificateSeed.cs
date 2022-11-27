using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Seeds
{
    public class CertificateSeed : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.HasData(new Certificate
            {
                Id = "1",
                AppUserId = "1",
                EventId = 1,
                CreatedAt = DateTime.Now,
                IsActive = true,
                Template = 1,
            },
            new Certificate
            {
                Id = "2",
                AppUserId = "1",
                EventId = 2,
                CreatedAt = DateTime.Now,
                IsActive = true,
                Template = 1,
            });
        }
    }
}
