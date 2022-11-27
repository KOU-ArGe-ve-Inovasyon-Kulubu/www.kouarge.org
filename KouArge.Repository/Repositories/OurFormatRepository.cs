using KouArge.Core.Models;
using KouArge.Core.Repositories;

namespace KouArge.Repository.Repositories
{
    public class OurFormatRepository : GenericRepository<OurFormat>, IOurFormatRepository
    {
        public OurFormatRepository(AppIdentityDbContext context) : base(context)
        {
        }
    }
}
