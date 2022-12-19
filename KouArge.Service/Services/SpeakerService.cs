using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;
using KouArge.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Service.Services
{
    public class SpeakerService : Service<Speaker>, ISpeakerService
    {
        private ISpeakerRepository _speakerRepository;
        private IMapper _mapper;
        public SpeakerService(IUnitOfWork unitOfWork, IGenericRepository<Speaker> repository, ISpeakerRepository speakerRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _speakerRepository = speakerRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<IEnumerable<SpeakerDto>>> GetAllByEventIdAsync(int eventId)
        {
            var speakers = await _speakerRepository.GetAllByEventIdAsync(eventId);

            if(speakers ==null)
                throw new NotFoundException($"{typeof(Speaker).Name}({eventId}) not found.");

            var speakerDto = _mapper.Map<IEnumerable<SpeakerDto>>(speakers);

            return CustomResponseDto<IEnumerable<SpeakerDto>>.Success(200, speakerDto);
        }

    }
}
