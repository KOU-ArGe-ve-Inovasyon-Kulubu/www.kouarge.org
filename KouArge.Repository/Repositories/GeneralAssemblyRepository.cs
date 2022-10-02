﻿using KouArge.Core.Models;
using KouArge.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Repository.Repositories
{
    public class GeneralAssemblyRepository : GenericRepository<GeneralAssembly>, IGeneralAssemblyRepository
    {
        public GeneralAssemblyRepository(AppIdentityDbContext context) : base(context)
        {
        }
    }
}
