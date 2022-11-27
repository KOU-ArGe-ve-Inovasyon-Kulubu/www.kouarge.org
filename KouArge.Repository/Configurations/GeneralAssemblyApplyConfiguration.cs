using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Configurations
{
    public class GeneralAssemblyApplyConfiguration : IEntityTypeConfiguration<GeneralAssemblyApply>
    {
        public void Configure(EntityTypeBuilder<GeneralAssemblyApply> builder)
        {
            builder.HasMany(x => x.TeamMembers).WithOne(x => x.GeneralAssemblyApply).HasForeignKey(x => x.GeneralAssemblyApplyId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
