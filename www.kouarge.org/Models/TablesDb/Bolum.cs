using Microsoft.EntityFrameworkCore;
using www.kouarge.org.Identity;

namespace www.kouarge.org.Models.TablesDb
{
    public class Bolum
    {
        public int id { get; set; }
        public string isim { get; set; }
        public int fakulteId { get; set; }

    }
}
