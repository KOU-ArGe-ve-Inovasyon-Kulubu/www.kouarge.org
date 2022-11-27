namespace KouArge.Core.Models
{
    public class Notification : BaseEntity
    {
        public int Sms { get; set; }
        public int Email { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }

    }
}
