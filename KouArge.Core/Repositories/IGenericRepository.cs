using System.Linq.Expressions;

namespace KouArge.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        IQueryable<T> GetAllInclude(params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAllPredicate(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdPredicateAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllIncludeFindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        void RemoveRange(IEnumerable<T> entities);
        void SoftRemove(T entity);

    }
}
