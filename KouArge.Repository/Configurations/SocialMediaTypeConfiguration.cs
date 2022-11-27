using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Configurations
{
    public class SocialMediaTypeConfiguration : IEntityTypeConfiguration<SocialMediaType>
    {
        public void Configure(EntityTypeBuilder<SocialMediaType> builder)
        {

        }
    }
}
