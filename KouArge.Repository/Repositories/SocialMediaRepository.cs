using KouArge.Core.Models;
using KouArge.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Repository.Repositories
{
    public class SocialMediaRepository : GenericRepository<SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public async Task<bool> DuplicateData(int socialMediaTypeId, string userId, int teamMemberId)
        {
            var teamMember = await _context.TeamMembers.FirstOrDefaultAsync(x => x.Id == teamMemberId && x.AppUserId == userId);

            if (teamMember != null && teamMember.Id != teamMemberId)
                return true;

            if (teamMember == null)
                return false;

            // var data = await _context.SocialMedias.FirstOrDefaultAsync(x => x.SocaialMediaTypeId == socialMediaTypeId
            //&& x.TeamMemberId == teamMember.Id);

            //if (data != null)
            //    return true;
            //else
            //    return false;

            var data = await _context.SocialMedias.AnyAsync(x => x.SocaialMediaTypeId == socialMediaTypeId
         && x.TeamMemberId == teamMember.Id);

            return data;
        }

        public async Task<bool> DuplicateData(int socialMediaTypeId, string userId)
        {
            var teamMember = await _context.TeamMembers.FirstOrDefaultAsync(x => x.AppUserId == userId);

            if (teamMember == null)
                return false;

            var data = await _context.SocialMedias.AnyAsync(x => x.SocaialMediaTypeId == socialMediaTypeId
         && x.TeamMemberId == teamMember.Id);

            return data;
        }

        public IQueryable<SocialMedia> GetAllWithDetails()
        {
            return _context.SocialMedias.Include(x => x.SocaialMediaType).Include(x => x.TeamMember).AsQueryable().AsNoTracking();
        }

        public async Task<SocialMedia> GetByIdWithDetailsAsync(int id)
        {
            return await _context.SocialMedias.Include(x => x.SocaialMediaType).Include(x => x.TeamMember).Where(x => x.Id == id).FirstOrDefaultAsync();

        }
    }
}
