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
    public class SocialMediaService : Service<SocialMedia>, ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;

        public SocialMediaService(IUnitOfWork unitOfWork, IGenericRepository<SocialMedia> repository, ISocialMediaRepository socialMediaRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
        }
     
    }
}
