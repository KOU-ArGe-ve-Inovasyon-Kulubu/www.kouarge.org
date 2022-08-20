namespace www.kouarge.org.Models.TablesDb
{
    public class TeamMember
    {
        public int Id { get; set; }
        public int GeneralAssemblyId { get; set; }
        public int TeamID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
