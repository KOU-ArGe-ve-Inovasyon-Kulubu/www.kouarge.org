using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;
using KouArge.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KouArge.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;
        public Service(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }


        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException($"{typeof(T).Name}({id}) not found.");

            return entity;
        }

        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async
            Task SoftRemove(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }

        public async Task<IEnumerable<T>> GetAllInclude(params Expression<Func<T, object>>[] includes)
        {
            return await _repository.GetAllInclude(includes).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllIncludeFindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return await _repository.GetAllIncludeFindBy(predicate, includes).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllPredicate(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetAllPredicate(predicate).ToListAsync();
        }

        public async Task<T> GetByIdPredicateAsync(Expression<Func<T, bool>> predicate)
        {

            var entity = await _repository.GetByIdPredicateAsync(predicate);
            if (entity == null)
                throw new NotFoundException($"{typeof(T).Name}({predicate.Body}) not found.");

            return entity;

        }

    }
}
