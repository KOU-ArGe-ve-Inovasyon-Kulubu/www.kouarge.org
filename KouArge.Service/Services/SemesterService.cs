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
    public class SemesterService : Service<Semester>, ISemesterService
    {
        private readonly ISemesterRepository _semesterRepository;
        private readonly IMapper _mapper;
        public SemesterService(IUnitOfWork unitOfWork, IGenericRepository<Semester> repository, ISemesterRepository semesterRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _semesterRepository = semesterRepository;
            _mapper = mapper;
        }
    }
}
