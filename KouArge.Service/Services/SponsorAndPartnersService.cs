using AutoMapper;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;

namespace KouArge.Service.Services
{
    public class SponsorAndPartnersService : Service<SponsorsAndPartners>, ISponsorAndPartnersService
    {
        private readonly ISponsorAndPartnersRepository _sponsorAndPartnersRepository;
        private readonly IMapper _mapper;
        public SponsorAndPartnersService(IUnitOfWork unitOfWork, IGenericRepository<SponsorsAndPartners> repository, ISponsorAndPartnersRepository sponsorAndPartnersRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _sponsorAndPartnersRepository = sponsorAndPartnersRepository;
            _mapper = mapper;
        }
    }
}
