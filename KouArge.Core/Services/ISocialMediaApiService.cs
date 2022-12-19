using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services
{
    public interface ISocialMediaApiService
    {
        Task<List<SocialMediaTypeDto>> GetAllType();
        Task<List<SocialMediaDto>> GetAll();
        Task<CustomResponseDto<NoContentDto>> DeleteSocialMedia(int id);

        Task<CustomResponseDto<SocialMediaTypeDto>> AddSocialMedia(SocialMediaTypeDto dataDto);
    }
}
