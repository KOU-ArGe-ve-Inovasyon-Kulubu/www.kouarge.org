﻿using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class EventWithFormatDto:EventDto
    {
        public OurFormatDto OurFormat { get; set; }
    }
}
