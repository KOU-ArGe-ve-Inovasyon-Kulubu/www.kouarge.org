using KouArge.Core.Models;
using KouArge.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Repository.Repositories
{
    public class CertificateRepository : GenericRepository<Certificate>, ICertificateRepository
    {
        public CertificateRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public async Task<Certificate> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<Certificate> GetByIdWithDetailsAsync(string id)
        {
            return await _dbSet.Include(x => x.AppUser).Include(x => x.Event).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DuplicateData(int eventId, string userId)
        {

            return await _context.Certificates.AnyAsync(x => x.EventId == eventId && x.AppUserId == userId);

            //return await _context.Certificates.SingleOrDefaultAsync(x => x.EventId == eventId && x.AppUserId == userId);

        }

        public IQueryable<Certificate> GetAllWithDetails()
        {
            return _context.Certificates.Include(x => x.AppUser).Include(x => x.Event).AsQueryable().AsNoTracking();
        }
    }
}
