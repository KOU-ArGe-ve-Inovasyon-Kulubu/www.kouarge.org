using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KouArge.Repository.Seeds
{
    public class OurFormatSeed : IEntityTypeConfiguration<OurFormat>
    {
        public void Configure(EntityTypeBuilder<OurFormat> builder)
        {
            var List = new List<OurFormat>();
            for (int i = 1; i < 6; i++)
            {
                var data = new OurFormat()
                {
                    Id = i,
                    Name = "Format" + i,
                    Description = "Description" + i,
                    Keywords = "Keywords" + i,
                    ImgUrl = "Url" + i,
                    IsActive = true,
                    CreatedAt = DateTime.Now,


                };
                List.Add(data);
            }
            builder.HasData(List);
        }
    }
}
