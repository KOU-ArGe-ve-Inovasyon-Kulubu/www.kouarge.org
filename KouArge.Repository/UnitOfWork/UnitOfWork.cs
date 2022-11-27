using KouArge.Core.UnitOfWorks;

namespace KouArge.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppIdentityDbContext _context;

        public UnitOfWork(AppIdentityDbContext identityDbContext)
        {
            _context = identityDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
