using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Models
{
    public class Notification:BaseEntity
    {
        public int Sms { get; set; }
        public int Email { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }

    }
}
