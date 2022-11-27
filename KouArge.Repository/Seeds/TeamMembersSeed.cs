using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Seeds
{
    public class TeamMembersSeed : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.HasData(new TeamMember()
            {
                Id = 1,
                TeamId = 1,
                AppUserId = "1",
                ImgUrl = "ImageUrl",
                TitleId = 1,
                CreatedAt = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                GeneralAssemblyApplyId = 2,
                IsActive = true,
            });
        }
    }
}
