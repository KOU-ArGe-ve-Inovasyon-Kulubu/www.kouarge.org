using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;
using KouArge.Repository;
using KouArge.Repository.Repositories;
using KouArge.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Service.Services
{
    public class RedirectService : IRedirectService
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly AppIdentityDbContext _context;
        protected readonly DbSet<Redirect> _dbSet;


        public RedirectService(IUnitOfWork unitOfWork, AppIdentityDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Redirect>();
            _unitOfWork = unitOfWork;
        }

        public async Task<string> AddAsync(string id)
        {
            var qr = await _context.Redirects.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (qr == null)
                throw new NotFoundException($"{typeof(Redirect).Name}({id}) not found.");

            qr.Count += 1;
            await _unitOfWork.CommitAsync();

            return qr.Url;

        }
    }
}

