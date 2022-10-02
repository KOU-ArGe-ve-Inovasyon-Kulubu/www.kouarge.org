using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class GeneralAssemblyApplyDto:BaseDto
    {
        public ICollection<Team> Team { get; set; }

        public ICollection<AppUser> Users { get; set; }//?? bak
    }
}
