using AutoMapper;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
