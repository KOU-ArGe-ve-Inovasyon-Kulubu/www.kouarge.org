namespace www.kouarge.org.Models.TablesDb
{
    public class GeneralAssemblyApply
    {
        public int Id { get; set; }
        public int MemberID { get; set; }
        public int TeamID { get; set; }
        public string Introducing { get; set; }
        public string Why { get; set; }
        public string SituationDescription { get; set; }
        public int Staus { get; set; } //ToDo : Enum eklenecek
       
        public string ApplyTime { get; set; }

    }
}
