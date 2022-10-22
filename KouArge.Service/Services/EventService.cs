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
    public class EventService : Service<Event>, IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventService(IUnitOfWork unitOfWork, IGenericRepository<Event> repository, IEventRepository eventRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
    }
}
