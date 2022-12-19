using KouArge.Core.Models;
using KouArge.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Repository.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public IQueryable<Event> GetAllWithDetails()
        {
            return _context.Events.Include(x => x.Speakers).Include(x => x.EventPictures).AsQueryable().AsNoTracking();
            //var data = GetAllInclude(x => x.Speakers,x=>x.EventPictures).AsQueryable().AsNoTracking();
        }

        public IQueryable<Event> GetAllWithFormat()
        {
            return _context.Events.Include(x => x.OurFormat).AsQueryable().AsNoTracking();
            //var data = GetAllInclude(x => x.Speakers,x=>x.EventPictures).AsQueryable().AsNoTracking();
        }
        public async Task<Event> GetByIdWithDetailsAsync(int id)
        {
            return _context.Events.Include(x => x.Speakers).Include(x => x.EventPictures).Where(x => x.Id == id).SingleOrDefault();
            //var data = GetAllIncludeFindBy(x=>x.Id==id,x => x.Speakers,x=>x.EventPictures).SingleOrDefault();
        }

    }
}
