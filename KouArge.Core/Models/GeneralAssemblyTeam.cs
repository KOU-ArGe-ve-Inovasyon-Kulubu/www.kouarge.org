using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Models
{
    public class GeneralAssemblyTeam:BaseEntity
    {
        public int GeneralAssemblyId { get; set; }
        public GeneralAssembly GeneralAssembly { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }

    }
}
