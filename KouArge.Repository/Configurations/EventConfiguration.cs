using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Repository.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x=>x.Speaker).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.EventDate).IsRequired();
            builder.Property(x => x.Url).IsRequired();
            builder.HasOne(x=>x.Semester).WithMany(x=>x.Events).HasForeignKey(x=>x.SemesterId);
            builder.HasOne(x => x.OurFormat).WithOne(x => x.Event).HasForeignKey<Event>(x => x.OurFormatId);
        }
    }
}
