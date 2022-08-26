namespace www.kouarge.org.Models.TablesDb
{
    public class Etkinlik
    {
        public int id { get; set; }
        public int formatId { get; set; }
        public int donemId { get; set; }
        public string isim { get; set; }
        public string aciklama { get; set; }
        public string konusmaci { get; set; }
        public DateTime tarih { get; set; }
        //public bit online { get; set; }
        public string url { get; set; }
    }
}
