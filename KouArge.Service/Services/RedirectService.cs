using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Models;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;
using KouArge.Repository;
using KouArge.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Service.Services
{
    public class RedirectService : IRedirectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppIdentityDbContext _context;
        private readonly DbSet<Redirect> _dbSet;

        public RedirectService(IUnitOfWork unitOfWork, AppIdentityDbContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<Redirect>();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CustomResponseDto<Redirect>> AddAsync(RedirectDto redirectDto)
        {
            var data = await _dbSet.Where(x => x.Name == redirectDto.Name).SingleOrDefaultAsync();

            if (data != null)
                return CustomResponseDto<Redirect>.Fail(400, new ErrorViewModel() { ErrorCode = "Exist", ErrorMessage = $"{typeof(Redirect).Name}({redirectDto.Name}) already exist." });

            redirectDto.IsActive = true;
            var redirect = _mapper.Map<Redirect>(redirectDto);

            await _dbSet.AddAsync(redirect);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<Redirect>.Success(200, redirect);
        }
        public async Task<string> AddCountAsync(string Name)
        {
            var qr = await _dbSet.Where(x => x.Name == Name).SingleOrDefaultAsync();

            if (qr == null)
                throw new NotFoundException($"{typeof(Redirect).Name}({Name}) not found.");

            if (!qr.IsActive)
                return null;

            qr.Count += 1;
            await _unitOfWork.CommitAsync();

            return qr.Url;

        }
        public async Task<CustomResponseDto<List<Redirect>>> GetAllAsync()
        {
            var redirectList = await _dbSet.AsNoTracking().ToListAsync();
            return CustomResponseDto<List<Redirect>>.Success(200, redirectList);
        }

        public async Task<CustomResponseDto<RedirectDto>> GetByIdAsync(int id)
        {
            var redirect = await _dbSet.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (redirect == null)
                throw new NotFoundException($"{typeof(Redirect).Name}({id}) not found.");

            var redirectDto = _mapper.Map<RedirectDto>(redirect);

            return CustomResponseDto<RedirectDto>.Success(200, redirectDto);
        }

        public async Task<CustomResponseDto<Redirect>> UpdateAsync(RedirectUpdateDto redirectDto)
        {
            var data = await _dbSet.Where(x => x.Id == redirectDto.Id).AsNoTracking().SingleOrDefaultAsync();
            if (data == null)
                throw new NotFoundException($"{typeof(Redirect).Name}({redirectDto.Id}) not found.");

            var redirect = _mapper.Map<Redirect>(redirectDto);

            _dbSet.Update(redirect);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<Redirect>.Success(204);
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteAsync(int id)
        {
            var data = await _dbSet.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (data == null)
                throw new NotFoundException($"{typeof(Redirect).Name}({id}) not found.");

            _dbSet.Remove(data);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<NoContentDto>> SoftDelete(int id)
        {
            var data = await _dbSet.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (data == null)
                throw new NotFoundException($"{typeof(Redirect).Name}({id}) not found.");

            data.IsActive = false;
            _dbSet.Update(data);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(204);
        }

    }
}

