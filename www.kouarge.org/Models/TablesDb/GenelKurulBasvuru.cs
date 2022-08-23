namespace www.kouarge.org.Models.TablesDb
{
    public class GenelKurulBasvuru
    {
        public int id { get; set; }
        public int uyeId { get; set; }
        public int takimId { get; set; }
        public string tanitim { get; set; }
        public string neden { get; set; }
        //public  bit durum{ get; set; }
        public string durumAciklama { get; set; }
        public DateTime basvuruTarihi { get; set; }
        public DateTime sonTarih { get; set; }

    }
}
