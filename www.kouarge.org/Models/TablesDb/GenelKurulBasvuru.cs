namespace www.kouarge.org.Models.TablesDb
{
    public class GeneralAssemblyApply
    {
<<<<<<< HEAD
        public int Id { get; set; }
        public int MemberID { get; set; }
        public int TeamID { get; set; }
        public string Introducing { get; set; }
        public string Why { get; set; }
        public string SituationDescription { get; set; }
        public int Staus { get; set; } //ToDo : Enum eklenecek
       
        public string ApplyTime { get; set; }
=======
        public int id { get; set; }
        public int uyeId { get; set; }
        public int takimId { get; set; }
        public string tanitim { get; set; }
        public string neden { get; set; }
        //public  bit durum{ get; set; }
        public string durumAciklama { get; set; }
        public DateTime basvuruTarihi { get; set; }
        public DateTime sonTarih { get; set; }
>>>>>>> 7c417516c2f1977ebb158f4fd7cee7bcf0d5f59c

    }
}
