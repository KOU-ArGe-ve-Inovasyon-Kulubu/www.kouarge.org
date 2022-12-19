using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.Tokens;
using KouArge.Core.UnitOfWorks;
using KouArge.Service.Exceptions;

namespace KouArge.Service.Services
{
    public class EventParticipantService : Service<EventParticipant>, IEventParticipantService
    {
        private readonly IEventParticipantRepository _eventParticipantRepository;
        private readonly ITokenHandler _tokenHandler;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public EventParticipantService(IUnitOfWork unitOfWork, IGenericRepository<EventParticipant> repository, IEventParticipantRepository eventParticipantRepository, ITokenHandler tokenHandler, IMapper mapper) : base(unitOfWork, repository)
        {
            _eventParticipantRepository = eventParticipantRepository;
            _tokenHandler = tokenHandler;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<IEnumerable<EventParticipantDto>>> GetAllByEventIdAsync(int eventId)
        {
            var data = await _eventParticipantRepository.GetAllByEventIdAsync(eventId);
            if (data == null)
                throw new NotFoundException($"{typeof(EventParticipantDto).Name}({eventId}) not found.");

            var dataDto= _mapper.Map<IEnumerable<EventParticipantDto>>(data);

            return CustomResponseDto<IEnumerable<EventParticipantDto>>.Success(200, dataDto);

        }

        public async Task<CustomResponseDto<EventParticipantDto>> AddAsync(string token, EventParticipant eventParticipant)
        {
            var decodedtoken = _tokenHandler.DecodeToken(token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;

            eventParticipant.AppUserId = userId;

            //if (userId != eventParticipant.AppUserId)
            //    throw new NotFoundException($"{typeof(AppUser).Name}({userId}) not found.");

            //var user = await _userManager.FindByIdAsync(userId);

            //if (user == null)
            //    throw new NotFoundException($"{typeof(AppUser).Name}({userId}) not found.");

            await  _eventParticipantRepository.AddAsync(eventParticipant);
            await _unitOfWork.CommitAsync();


            var eventParticipantsDto = _mapper.Map<EventParticipantDto>(eventParticipant);

            return CustomResponseDto<EventParticipantDto>.Success(201, eventParticipantsDto);
        }

        public async Task DuplicateData(int eventId, string userId)
        {
            var data = await _eventParticipantRepository.DuplicateData(eventId, userId);

            if (data)
                throw new ClientSideException("Dublicate data");
        }

        public async Task<EventParticipant> GetByEventId(int eventId)
        {
            var data = await _eventParticipantRepository.GetByIdAsync(eventId);

            if (data != null)
                throw new NotFoundException("Not Found");

            return data;
        }


        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(DeleteDto deleteDto)
        {
            var decodedtoken = _tokenHandler.DecodeToken(deleteDto.Token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;


            var eventParticipant = await _eventParticipantRepository.GetByIdAsync(deleteDto.Id);

            if (eventParticipant == null || eventParticipant.AppUserId != userId)
                throw new ClientSideException("User not found.");

            _eventParticipantRepository.Remove(eventParticipant);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(204);

        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveByIdAsync(int id)
        {

            var eventParticipant = await _eventParticipantRepository.GetByIdAsync(id);

            if (eventParticipant == null)
                throw new ClientSideException("Event not found.");

            _eventParticipantRepository.Remove(eventParticipant);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(204);

        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveByUserIdAsync(DeleteByUserIdDto deleteDto)
        {

            var eventParticipant = await _eventParticipantRepository.GetByEventId(deleteDto.Id);

            //eventParticipant Id lazım....

            if (eventParticipant == null || eventParticipant.AppUserId != deleteDto.UserId)
                throw new ClientSideException("User not found.");

            _eventParticipantRepository.Remove(eventParticipant);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(204);

        }
    }
}
