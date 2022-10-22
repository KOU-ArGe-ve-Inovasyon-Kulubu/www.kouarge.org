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
    public class OurFormatService : Service<OurFormat>, IOurFormatService
    {
        private readonly IOurFormatRepository _ourFormatRepository;
        private readonly IMapper _mapper;
        public OurFormatService(IUnitOfWork unitOfWork, IGenericRepository<OurFormat> repository, IOurFormatRepository ourFormatRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _ourFormatRepository = ourFormatRepository;
            _mapper = mapper;
        }
    }
}
