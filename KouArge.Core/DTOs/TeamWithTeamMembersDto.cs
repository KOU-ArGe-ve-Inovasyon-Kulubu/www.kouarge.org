using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class TeamWithTeamMembersDto:TeamDto
    {
        public ICollection<TeamMemberDto> TeamMembers { get; set; }
    }
}
