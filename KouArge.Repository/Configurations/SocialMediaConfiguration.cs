using KouArge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Repository.Configurations
{
    public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.HasKey(x => x.Id);



            builder.HasOne(x => x.GeneralAssembly).WithMany(x => x.SocialMedias).HasForeignKey(x => x.generalAssemblyId);
        }
    }
}
