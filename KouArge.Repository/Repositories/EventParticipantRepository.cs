﻿using KouArge.Core.Models;
using KouArge.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Repository.Repositories
{
    public class EventParticipantRepository : GenericRepository<EventParticipant>, IEventParticipantRepository
    {
        public EventParticipantRepository(AppIdentityDbContext context) : base(context)
        {
        }
    }
}
