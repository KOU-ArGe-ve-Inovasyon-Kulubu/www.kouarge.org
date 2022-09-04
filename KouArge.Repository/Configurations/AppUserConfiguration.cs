using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace KouArge.Repository.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.StudentNo).HasMaxLength(9);
            builder.HasIndex(x => new { x.StudentNo }).IsUnique();
            builder.HasOne(x=>x.Department).WithMany(x=>x.AppUsers).HasForeignKey(x=>x.DepartmentId);
        }
    }
}
