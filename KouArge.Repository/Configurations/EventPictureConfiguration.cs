using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Configurations
{
    public class EventPictureConfiguration : IEntityTypeConfiguration<EventPicture>
    {
        public void Configure(EntityTypeBuilder<EventPicture> builder)
        {
            //builder.HasOne(x => x.Event).WithMany(x => x.EventPictures).HasForeignKey(x => x.EventId);
        }
    }
}
