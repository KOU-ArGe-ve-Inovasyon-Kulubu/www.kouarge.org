using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Repository.Repositories
{
    public class SpeakerRepository : GenericRepository<Speaker>, ISpeakerRepository
    {
        public SpeakerRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Speaker>> GetAllByEventIdAsync(int eventId)
        {
           return await _context.Speakers.Where(x => x.EventId == eventId).AsNoTracking().ToListAsync();
        }

    }
}
