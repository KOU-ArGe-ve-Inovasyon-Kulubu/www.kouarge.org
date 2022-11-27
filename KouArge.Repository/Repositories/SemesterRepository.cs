using KouArge.Core.Models;
using KouArge.Core.Repositories;

namespace KouArge.Repository.Repositories
{
    public class SemesterRepository : GenericRepository<Semester>, ISemesterRepository
    {
        public SemesterRepository(AppIdentityDbContext context) : base(context)
        {
        }
    }
}
