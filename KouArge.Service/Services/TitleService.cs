using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;
using KouArge.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Service.Services
{
    public class TitleService : Service<Title>, ITitleService
    {
        private readonly ITitleRepository _titleRepository;
        public TitleService(IUnitOfWork unitOfWork, IGenericRepository<Title> repository, ITitleRepository titleRepository) : base(unitOfWork, repository)
        {
            _titleRepository = titleRepository;
        }

        public async Task DuplicateDataAsync(string titleName)
        {
            var data = await _titleRepository.DuplicateDataAsync(titleName);
            if(data)
                throw new ClientSideException("Dublicate data");
        }

    }
}
