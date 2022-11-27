using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Seeds
{
    public class NotificationSeed : IEntityTypeConfiguration<Notification>
    {

        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasData(new Notification()
            {
                Id = 1,
                Email = 1,
                Sms = 1,
                CreatedAt = DateTime.Now,
                IsActive = true,
            },
            new Notification()
            {
                Id = 2,
                Email = 1,
                Sms = 0,
                CreatedAt = DateTime.Now,
                IsActive = true,

            },
            new Notification()
            {
                Id = 3,
                Email = 0,
                Sms = 1,
                CreatedAt = DateTime.Now,
                IsActive = true,

            },
            new Notification()
            {
                Id = 4,
                Email = 0,
                Sms = 0,
                CreatedAt = DateTime.Now,
                IsActive = true,

            });
        }
    }

}
