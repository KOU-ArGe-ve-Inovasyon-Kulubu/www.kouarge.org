using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Seeds
{
    public class DepartmentSeed : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(new Department()
            {
                Id = "1",
                Name = "Bil Sis. Müh.",
                FacultyId = 1,
                CreatedAt = DateTime.Now,
                IsActive = true,
            });
        }
    }
}
