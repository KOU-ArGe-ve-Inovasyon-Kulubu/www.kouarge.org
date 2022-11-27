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
    public class EventService : Service<Event>, IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventService(IUnitOfWork unitOfWork, IGenericRepository<Event> repository, IEventRepository eventRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<IEnumerable<EventWithPictureDto>>> GetAllWithDetails()
        {
            var data = await _eventRepository.GetAllWithDetails().OrderByDescending(x => x.EventDate).ToListAsync();
            var dataDto = _mapper.Map<IEnumerable<EventWithPictureDto>>(data);
            return CustomResponseDto<IEnumerable<EventWithPictureDto>>.Success(200, dataDto.AsEnumerable());
        }

        public async Task<CustomResponseDto<EventWithPictureDto>> GetByIdWithDetailsAsync(int id)
        {
            var data = await _eventRepository.GetByIdWithDetailsAsync(id);

            if (data == null)
                throw new NotFoundException($"{typeof(Event).Name}({id}) not found.");

            var dataDto = _mapper.Map<EventWithPictureDto>(data);
            return CustomResponseDto<EventWithPictureDto>.Success(200, dataDto);
        }


    }
}
