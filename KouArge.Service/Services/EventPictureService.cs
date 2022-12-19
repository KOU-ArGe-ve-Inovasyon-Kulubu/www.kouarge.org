using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;
using KouArge.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Service.Services
{
    public class EventPictureService : Service<EventPicture>, IEventPictureService
    {
        private readonly IEventPictureRepository _eventPictureRepository;
        private readonly IMapper _mapper;
        public EventPictureService(IUnitOfWork unitOfWork, IGenericRepository<EventPicture> repository, IEventPictureRepository eventPictureRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _eventPictureRepository = eventPictureRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<IEnumerable<EventPictureDto>>> GetAllByEventId(int eventId)
        {
            var data = await _eventPictureRepository.GetByEventId(eventId).ToListAsync();

            if (data == null)
                throw new NotFoundException($"{typeof(EventPicture).Name}({eventId}) not found.");

            var dataDto = _mapper.Map<IEnumerable<EventPictureDto>>(data);

            return CustomResponseDto<IEnumerable<EventPictureDto>>.Success(200, dataDto);
        }


    }
}
