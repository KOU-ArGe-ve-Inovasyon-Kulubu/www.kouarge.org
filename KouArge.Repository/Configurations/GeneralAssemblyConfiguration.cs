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
    internal class GeneralAssemblyConfiguration : IEntityTypeConfiguration<GeneralAssembly>
    {
        public void Configure(EntityTypeBuilder<GeneralAssembly> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.HasOne(x => x.User).WithOne(x => x.GeneralAssembly).HasForeignKey<GeneralAssembly>(x => x.UserId);

            //public ICollection<Team> Teams { get; set; }
            //public ICollection<TeamMember> TeamMembers { get; set; }

        }
    }
}

