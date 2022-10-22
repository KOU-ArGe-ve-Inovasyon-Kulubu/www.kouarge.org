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
    public class EventParticipantService : Service<EventParticipant>, IEventParticipantService
    {
        private readonly IEventParticipantRepository _eventParticipantRepository;
        private readonly IMapper _mapper;
        public EventParticipantService(IUnitOfWork unitOfWork, IGenericRepository<EventParticipant> repository, IEventParticipantRepository eventParticipantRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _eventParticipantRepository = eventParticipantRepository;
            _mapper = mapper;
        }
    }
}
