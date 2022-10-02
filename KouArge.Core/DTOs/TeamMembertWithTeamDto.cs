using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class TeamMembertWithTeamDto:TeamMemberDto
    {
        public TeamDto Team { get; set; }
    }
}
