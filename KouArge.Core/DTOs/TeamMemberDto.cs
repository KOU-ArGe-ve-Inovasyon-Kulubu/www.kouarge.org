using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class TeamMemberDto:BaseDto
    {
        public string Title { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<GeneralAssemblyDto> GeneralAssemblies { get; set; }
    }
}
