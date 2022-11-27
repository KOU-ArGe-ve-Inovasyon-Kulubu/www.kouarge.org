using KouArge.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KouArge.Repository
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<EventPicture> EventPictures { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        //public DbSet<GeneralAssembly> GeneralAssemblies { get; set; }
        public DbSet<GeneralAssemblyApply> GeneralAssemblyApplies { get; set; }
        public DbSet<OurFormat> OurFormats { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<SocialMediaType> SocaialMediaTypes { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SponsorsAndPartners> SponsorsAndPartners { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        //public DbSet<GeneralAssemblyTeam> GeneralAssemblyTeams { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Title> Titles { get; set; }

        public DbSet<Certificate> Certificates { get; set; }


        //***************
        public DbSet<Redirect> Redirects { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedAt = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedAt).IsModified = false;
                                entityReference.UpdatedAt = DateTime.Now;
                                break;
                            }
                    }
                }

                if (item.Entity is AppUser appUser)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                appUser.CreatedAt = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(appUser).Property(x => x.CreatedAt).IsModified = false;
                                appUser.UpdatedAt = DateTime.Now;
                                break;
                            }
                    }
                }

                ////******************
                if (item.Entity is StringBaseEntity stringIdEntity)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                stringIdEntity.CreatedAt = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(stringIdEntity).Property(x => x.CreatedAt).IsModified = false;
                                stringIdEntity.UpdatedAt = DateTime.Now;
                                break;
                            }
                    }
                }

            }


            return base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedAt = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedAt).IsModified = false;
                                entityReference.UpdatedAt = DateTime.Now;
                                break;
                            }
                    }
                }

                if (item.Entity is AppUser appUser)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                appUser.CreatedAt = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(appUser).Property(x => x.CreatedAt).IsModified = false;
                                appUser.UpdatedAt = DateTime.Now;
                                break;
                            }
                    }
                }

                if (item.Entity is StringBaseEntity stringIdEntity)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                stringIdEntity.CreatedAt = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(stringIdEntity).Property(x => x.CreatedAt).IsModified = false;
                                stringIdEntity.UpdatedAt = DateTime.Now;
                                break;
                            }
                    }
                }
            }


            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            //modelBuilder.Entity<Department>().HasQueryFilter(p => p.IsActive);





            base.OnModelCreating(modelBuilder);
        }

    }
}
