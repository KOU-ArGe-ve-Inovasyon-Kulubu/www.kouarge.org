using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class GeneralAssemblyApplyWithUserDto:BaseDto
    {
        public int TeamId { get; set; }
        public string AppUserId { get; set; }

        public int TitleId { get; set; }
        public string Introducing { get; set; }
        public string Why { get; set; }
        public string SituationDescription { get; set; }
        public int AppStatus { get; set; } 
        public DateTime ApplyTime { get; set; }
        public AppUserDto Appuser { get; set; }
        public TeamDto Team { get; set; }
        public TitleDto Title { get; set; }
    }
}
