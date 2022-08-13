namespace www.kouarge.org.Models.TablesDb
{
    public class TakımUyeleri
    {
        public int id { get; set; }
        public int genelKurulId { get; set; }
        public int takımId { get; set; }
        public string title { get; set; }
        public DateTime ayrılmaTarihi { get; set; }
        public DateTime kayıtTarihi { get; set; }
    }
}
