using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Configurations
{
    public class OurFormatConfiguration : IEntityTypeConfiguration<OurFormat>
    {
        public void Configure(EntityTypeBuilder<OurFormat> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Keywords).IsRequired();



        }
    }
}
