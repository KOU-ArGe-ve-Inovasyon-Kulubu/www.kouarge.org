using KouArge.Core.Models;
using KouArge.Core.Repositories;

namespace KouArge.Repository.Repositories
{
    public class SponsorAndPartnersRepository : GenericRepository<SponsorsAndPartners>, ISponsorAndPartnersRepository
    {
        public SponsorAndPartnersRepository(AppIdentityDbContext context) : base(context)
        {
        }
    }
}
