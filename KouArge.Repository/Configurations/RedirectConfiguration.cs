using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Configurations
{
    internal class RedirectConfiguration : IEntityTypeConfiguration<Redirect>
    {
        public void Configure(EntityTypeBuilder<Redirect> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.Count).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
        }
    }
}
