using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Seeds
{
    internal class SemesterSeed : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            var List = new List<Semester>();
            for (int i = 1; i < 6; i++)
            {
                var data = new Semester()
                {
                    Id = i,
                    Name = "Semester" + i,
                    CreatedAt = DateTime.Now,
                    IsActive = true,

                };
                List.Add(data);
            }
            builder.HasData(List);
        }
    }
}
