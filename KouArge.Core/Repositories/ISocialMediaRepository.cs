using KouArge.Core.Models;

namespace KouArge.Core.Repositories
{
    public interface ISocialMediaRepository : IGenericRepository<SocialMedia>
    {
        IQueryable<SocialMedia> GetAllWithDetails();
        Task<bool> DuplicateData(int socialMediaTypeId, string userId, int teamMemberId);
        Task<SocialMedia> GetByIdWithDetailsAsync(int id);
        Task<bool> DuplicateData(int socialMediaTypeId, string userId);
    }
}
