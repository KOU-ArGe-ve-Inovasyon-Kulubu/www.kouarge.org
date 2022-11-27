using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Models;

namespace KouArge.Core.Services
{
    public interface ISocialMediaService : IService<SocialMedia>
    {
        public Task<CustomResponseDto<IEnumerable<SocialMediaDto>>> GetAllWithDetails();
        public Task DuplicateData(int socialMediaTypeId, string userId, int teamMemberId);
        public Task<CustomResponseDto<SocialMediaDto>> GetByIdWithDetailsAsync(int id);
        public Task<CustomResponseDto<NoContentDto>> UpdateAsync(SocialMediaUpdateDto socialMediaDto);
        public Task<CustomResponseDto<NoContentDto>> RemoveAsync(DeleteDto deleteDto);
    }
}
