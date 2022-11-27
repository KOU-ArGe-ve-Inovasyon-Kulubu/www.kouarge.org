using KouArge.Core.Models;
using KouArge.Core.Repositories;

namespace KouArge.Repository.Repositories
{
    public class SocialMediaTypeRepository : GenericRepository<SocialMediaType>, ISocialMediaTypeRepository
    {
        public SocialMediaTypeRepository(AppIdentityDbContext context) : base(context)
        {
        }
    }
}
