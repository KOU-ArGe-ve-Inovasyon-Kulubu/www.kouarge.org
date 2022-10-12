﻿using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class TeamMemberDto:BaseDto
    {
        public int GeneralAssemblyId { get; set; }
        public int TeamId { get; set; }
        public string Title { get; set; }
    }
}
