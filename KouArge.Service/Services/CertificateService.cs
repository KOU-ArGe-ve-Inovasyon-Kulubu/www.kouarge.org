using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.Tokens;
using KouArge.Core.UnitOfWorks;
using KouArge.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Service.Services
{
    public class CertificateService : Service<Certificate>, ICertificateService
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHandler _tokenHandler;
        public CertificateService(IUnitOfWork unitOfWork, IGenericRepository<Certificate> repository, ICertificateRepository certificateRepository, IMapper mapper, ITokenHandler tokenHandler) : base(unitOfWork, repository)
        {
            _certificateRepository = certificateRepository;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
        }

        public async Task DuplicateData(int eventId, string userId)
        {
            var data = await _certificateRepository.DuplicateData(eventId, userId);

            if (data)
                throw new ClientSideException("Dublicate data");
        }

        public async Task<CustomResponseDto<IEnumerable<AppUserWithCertificas>>> GetAllWithDetails()
        {
            var data = await _certificateRepository.GetAllWithDetails().ToListAsync();
            return CustomResponseDto<IEnumerable<AppUserWithCertificas>>.Success(200, _mapper.Map<IEnumerable<AppUserWithCertificas>>(data));
        }

        public async Task<Certificate> GetByIdAsync(string id)
        {
            var entity = await _certificateRepository.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException($"{typeof(Certificate).Name}({id}) not found.");

            return entity;
        }

        public async Task<Certificate> GetByIdWithDetailsAsync(string id)
        {
            var entity = await _certificateRepository.GetByIdWithDetailsAsync(id);
            if (entity == null)
                throw new NotFoundException($"{typeof(Certificate).Name}({id}) not found.");

            return entity;
        }

        public async Task<CustomResponseDto<CertificateDto>> AddAsync(string token, Certificate certificate)
        {
            var decodedtoken = _tokenHandler.DecodeToken(token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;

            certificate.AppUserId = userId;

            //if (userId != certificate.AppUserId)
            //    throw new NotFoundException($"{typeof(AppUser).Name}({userId}) not found.");

            //var user = await _userManager.FindByIdAsync(userId);

            //if (user == null)
            //    throw new NotFoundException($"{typeof(AppUser).Name}({userId}) not found.");

            var certificates = await AddAsync(certificate);
            var certificatesDto = _mapper.Map<CertificateDto>(certificates);

            return CustomResponseDto<CertificateDto>.Success(201, certificatesDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(CertificateUpdateDto certificateDto)
        {
            var decodedtoken = _tokenHandler.DecodeToken(certificateDto.Token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;

            certificateDto.AppUserId = userId;

            _certificateRepository.Update(_mapper.Map<Certificate>(certificateDto));

            return CustomResponseDto<NoContentDto>.Success(204);

        }

    }
}
