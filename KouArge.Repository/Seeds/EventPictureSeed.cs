using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Seeds
{
    public class EventPictureSeed : IEntityTypeConfiguration<EventPicture>
    {
        public void Configure(EntityTypeBuilder<EventPicture> builder)
        {
            var List = new List<EventPicture>();
            for (int i = 1; i < 6; i++)
            {
                var data = new EventPicture()
                {
                    Id = i,
                    EventId = i,
                    ImgUrl = "Url" + i,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                };
                List.Add(data);
            }
            builder.HasData(List);
        }
    }
}
