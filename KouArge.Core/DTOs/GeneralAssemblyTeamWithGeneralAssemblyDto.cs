﻿using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class GeneralAssemblyTeamWithGeneralAssemblyDto : GeneralAssemblyTeamDto
    {
        public GeneralAssemblyDto GeneralAssembly { get; set; }
    }
}
