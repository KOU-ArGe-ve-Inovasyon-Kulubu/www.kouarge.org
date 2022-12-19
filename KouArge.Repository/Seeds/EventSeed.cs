using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Seeds
{
    public class EventSeed : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            var List = new List<Event>();
            for (int i = 1; i < 6; i++)
            {
                var data = new Event()
                {
                    Id = i,
                    SemesterId = 1,
                    OurFormatId = i % 2 == 0 ? 1 : 2,
                    Description = "Descript" + i,
                    EventDate = DateTime.Now,
                    Title = "Title" + i,
                    Adress="adress"+i,
                    ImgBackUrl = "Url" + i,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                };
                List.Add(data);
            }
            builder.HasData(List);
        }
    }
}
