using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Models;

namespace KouArge.Core.Services
{
    public interface ICertificateService : IService<Certificate>
    {
        Task<Certificate> GetByIdAsync(string id);
        Task<CustomResponseDto<CertificateDto>> AddAsync(string token, Certificate certificate);
        Task<Certificate> GetByIdWithDetailsAsync(string id);
        Task<CustomResponseDto<IEnumerable<AppUserWithCertificas>>> GetAllWithDetails();
        Task DuplicateData(int eventId, string userId);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(CertificateUpdateDto certificateDto);
    }
}
