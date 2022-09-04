namespace KouArge.Core.Models
{
    public class GeneralAssemblyApply:BaseEntity
    {
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public string Introducing { get; set; }
        public string Why { get; set; }
        public string SituationDescription { get; set; }
        public int Staus { get; set; } //ToDo : Enum eklenecek
        public string ApplyTime { get; set; }

        public ICollection<Team> Team { get; set; }

        public ICollection<AppUser> Users { get; set; }//?? bak

    }
}
