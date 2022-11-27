using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Seeds
{
    public class SpeakerSeed : IEntityTypeConfiguration<Speaker>
    {
        public void Configure(EntityTypeBuilder<Speaker> builder)
        {
            var List = new List<Speaker>();
            for (int i = 1; i < 5; i++)
            {
                var data = new Speaker()
                {
                    Id = i,
                    EventId = i % 2 == 0 ? 1 : 2,
                    ImgUrl = "Spekare Url " + i,
                    Name = "Speaker Name " + i,
                    Url = "spekaer Url " + i,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                };
                List.Add(data);

                data = new Speaker()
                {
                    Id = i + 5,
                    EventId = i % 2 == 0 ? 1 : 2,
                    ImgUrl = "Spekare Url " + i + 1,
                    Name = "Speaker Name " + i + 1,
                    Url = "spekaer Url " + i + 1,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                };


                List.Add(data);
            }
            builder.HasData(List);
        }
    }
}
