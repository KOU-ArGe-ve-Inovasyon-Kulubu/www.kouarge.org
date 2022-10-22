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
    public class EventPictureService : Service<EventPicture>, IEventPictureService
    {
        private readonly IEventPictureRepository _eventPictureRepository;
        private readonly IMapper _mapper;
        public EventPictureService(IUnitOfWork unitOfWork, IGenericRepository<EventPicture> repository, IEventPictureRepository eventPictureRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _eventPictureRepository = eventPictureRepository;
            _mapper = mapper;
        }
    }
}
