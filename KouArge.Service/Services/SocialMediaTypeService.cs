using AutoMapper;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;

namespace KouArge.Service.Services
{
    public class SocialMediaTypeService : Service<SocialMediaType>, ISocialMediaTypeService
    {
        private readonly ISocialMediaTypeRepository _socialMediaTyperepository;
        private readonly IMapper _mapper;
        public SocialMediaTypeService(IUnitOfWork unitOfWork, IGenericRepository<SocialMediaType> repository, ISocialMediaTypeRepository socialMediaTyperepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _socialMediaTyperepository = socialMediaTyperepository;
            _mapper = mapper;
        }
    }
}
