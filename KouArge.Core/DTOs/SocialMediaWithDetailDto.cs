using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class SocialMediaWithDetailDto:BaseDto
    {
        public int TeamMemberId { get; set; }
        public string? Url { get; set; }
        public int SocaialMediaTypeId { get; set; }
        public SocialMediaTypeDto SocaialMediaType { get; set; }
        public TeamMemberDto TeamMember { get; set; }

        public AppUserDto AppUser { get; set; }
    }
}
