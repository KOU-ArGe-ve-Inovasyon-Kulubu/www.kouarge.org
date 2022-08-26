using Microsoft.EntityFrameworkCore;
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
        public DbSet<Bolum> Bolum { get; set; }
        public DbSet<Donem> Donem { get; set; }
        public DbSet<Etkinlik> Etkinlik { get; set; }
        public DbSet<EtkinlikKatilimciListesi> EtkinlikKatılımcıListesi { get; set; }
        public DbSet<EtkinlikResim> EtkinlikResim { get; set; }
        public DbSet<Fakulte> Fakulte { get; set; }
        public DbSet<Formatlarimiz> Formatlarımız { get; set; }
        public DbSet<GenelKurul> GenelKurul { get; set; }
        public DbSet<GenelKurulBasvuru> GenelKurulBasvuru { get; set; }
        public DbSet<SosyalMedya> SosyalMedya { get; set; }
        public DbSet<SosyalMedyaTipi> SosyalMedyaTıpı { get; set; }
        public DbSet<SponsorVePartnerler> SponsorVePartnerler { get; set; }
        public DbSet<Takim> Takım { get; set; }
        public DbSet<TakimUyeleri> TakımUyeleri { get; set; }
        #endregion
    }
}
