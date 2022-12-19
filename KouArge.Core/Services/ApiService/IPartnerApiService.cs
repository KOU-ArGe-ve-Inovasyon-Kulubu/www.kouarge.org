using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface IPartnerApiService
    {
        public Task<CustomResponseDto<IEnumerable<SponsorAndPartnersDto>>> GetAllAsync();
        public Task<CustomResponseDto<SponsorAndPartnersDto>> GetByIdAsync(int id);

        public Task<CustomResponseDto<SponsorAndPartnersDto>> AddAsync(SponsorAndPartnersDto sponsorDto);

        public Task<CustomResponseDto<NoContentDto>> UpdateAsync(SponsorAndPartnersDto sponsorDto);
        public Task<CustomResponseDto<NoContentDto>> DeleteAsync(int id);

    }
}
