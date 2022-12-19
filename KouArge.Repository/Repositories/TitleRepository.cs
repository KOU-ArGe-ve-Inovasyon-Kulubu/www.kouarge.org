using KouArge.Core.Models;
using KouArge.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Repository.Repositories
{
    public class TitleRepository : GenericRepository<Title>, ITitleRepository
    {
        public TitleRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public async Task<bool> DuplicateDataAsync(string titleName)
        {
          return await _context.Titles.AnyAsync(x => x.Name == titleName);
        }
    }
}
