using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using www.kouarge.org.Models.TablesDb;

namespace www.kouarge.org.Identity
{
    public class AppIdentityDbContext: IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options): base (options)
        {
           
        }

        #region
        public DbSet<Bolum> Bolum { get; set; }
        public DbSet<Donem> Donem { get; set; }
        public DbSet<Etkinlik> Etkinlik { get; set; }
        public DbSet<EtkinlikKatılımcıListesi> EtkinlikKatılımcıListesi { get; set; }
        public DbSet<EtkinlikResim> EtkinlikResim { get; set; }
        public DbSet<Fakulte> Fakulte { get; set; }
        public DbSet<Formatlarımız> Formatlarımız { get; set; }
        public DbSet<GenelKurul> GenelKurul { get; set; }
        public DbSet<GenelKurulBasvuru> GenelKurulBasvuru { get; set; }
        public DbSet<SocialMedia> SosyalMedya { get; set; }
        public DbSet<SocaialMediaType> SosyalMedyaTıpı { get; set; }
        public DbSet<SponsorsAndPartners> SponsorVePartnerler { get; set; }
        public DbSet<Team> Takım { get; set; }
        public DbSet<TeamMember> TakımUyeleri { get; set; }
        #endregion

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Bolum>().ToTable("BOLUM");
        //    modelBuilder.Entity<Donem>().ToTable("DONEM");
        //    modelBuilder.Entity<Etkinlik>().ToTable("ETKINLIK");
        //    modelBuilder.Entity<EtkinlikKatılımcıListesi>().ToTable("ETKINLIK_KATILIMCI_LISTESI");
        //    modelBuilder.Entity<EtkinlikResim>().ToTable("ETKINLIK_RESIM");
        //    modelBuilder.Entity<Fakulte>().ToTable("FAKULTE");
        //    modelBuilder.Entity<Formatlarımız>().ToTable("FORMATLARIMIZ");
        //    modelBuilder.Entity<GenelKurul>().ToTable("GENEL_KURUL");
        //    modelBuilder.Entity<GenelKurulBasvuru>().ToTable("GENEL_KURUL_BASVURU");
        //    modelBuilder.Entity<SosyalMedya>().ToTable("SOSYAL_MEDYA");
        //    modelBuilder.Entity<SosyalMedyaTıpı>().ToTable("SOSYAL_MEDYA_TIPI");
        //    modelBuilder.Entity<SponsorVePartnerler>().ToTable("SPONSOR_VE_PARTNERLER");
        //    modelBuilder.Entity<Takım>().ToTable("TAKIM");
        //    modelBuilder.Entity<TakımUyeleri>().ToTable("TAKIM_UYELERI");
        //}

    }
}
