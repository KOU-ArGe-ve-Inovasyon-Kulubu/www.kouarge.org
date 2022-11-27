using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Seeds
{
    public class EventParticipantSeed : IEntityTypeConfiguration<EventParticipant>
    {
        public void Configure(EntityTypeBuilder<EventParticipant> builder)
        {
            List<EventParticipant> list = new List<EventParticipant>();
            for (int i = 2; i < 5; i++)
            {
                var data = new EventParticipant()
                {
                    AppUserId = i % 2 == 0 ? "1" : "2",
                    CreatedAt = DateTime.Now,
                    EventId = i / 2,
                    Id = i,
                    IsActive = true,
                };

                list.Add(data);
            }



            builder.HasData(list);

        }


    }
}
