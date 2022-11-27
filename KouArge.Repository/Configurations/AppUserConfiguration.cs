using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.StudentNumber).HasMaxLength(9);
            builder.HasIndex(x => new { x.StudentNumber }).IsUnique();
            builder.HasIndex(x => new { x.PhoneNumber }).IsUnique();
            builder.HasOne(x => x.Department).WithMany(x => x.AppUsers).HasForeignKey(x => x.DepartmentId);
        }
    }
}
