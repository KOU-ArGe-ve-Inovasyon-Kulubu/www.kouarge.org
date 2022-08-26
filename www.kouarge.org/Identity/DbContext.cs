using Microsoft.EntityFrameworkCore;
using www.kouarge.org.Models;
using www.kouarge.org.Models.TablesDb;

namespace www.kouarge.org.Identity
{
    public class TablesDbContext : DbContext
    {
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Bolum>().ToTable("BOLUM");
        //    modelBuilder.Entity<Donem>().ToTable("DONEM");
        //    modelBuilder.Entity<Etkinlik>().ToTable("ETKINLIK");
        //    modelBuilder.Entity<EtkinlikKatilimciListesi>().ToTable("ETKINLIK_KATILIMCI_LISTESI");
        //    modelBuilder.Entity<EtkinlikResim>().ToTable("ETKINLIK_RESIM");
        //    modelBuilder.Entity<Fakulte>().ToTable("FAKULTE");
        //    modelBuilder.Entity<Formatlarimiz>().ToTable("FORMATLARIMIZ");
        //    modelBuilder.Entity<GenelKurul>().ToTable("GENEL_KURUL");
        //    modelBuilder.Entity<GenelKurulBasvuru>().ToTable("GENEL_KURUL_BASVURU");
        //    modelBuilder.Entity<SosyalMedya>().ToTable("SOSYAL_MEDYA");
        //    modelBuilder.Entity<SosyalMedyaTipi>().ToTable("SOSYAL_MEDYA_TIPI");
        //    modelBuilder.Entity<SponsorVePartnerler>().ToTable("SPONSOR_VE_PARTNERLER");
        //    modelBuilder.Entity<Takim>().ToTable("TAKIM");
        //    modelBuilder.Entity<TakimUyeleri>().ToTable("TAKIM_UYELERI");
        //}

        #region
        public DbSet<Department> Bolum { get; set; }
        public DbSet<Semester> Donem { get; set; }
        public DbSet<Event> Etkinlik { get; set; }
        public DbSet<EventParticipantList> EtkinlikKatılımcıListesi { get; set; }
        public DbSet<EventPicture> EtkinlikResim { get; set; }
        public DbSet<Faculty> Fakulte { get; set; }
        public DbSet<OurFormat> Formatlarımız { get; set; }
        public DbSet<GeneralAssembly> GenelKurul { get; set; }
        public DbSet<GeneralAssemblyApply> GenelKurulBasvuru { get; set; }
        public DbSet<SocialMedia> SosyalMedya { get; set; }
        public DbSet<SocaialMediaType> SosyalMedyaTıpı { get; set; }
        public DbSet<SponsorsAndPartners> SponsorVePartnerler { get; set; }
        public DbSet<Team> Takım { get; set; }
        public DbSet<TeamMember> TakımUyeleri { get; set; }
        #endregion
    }
}
