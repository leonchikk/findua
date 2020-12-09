using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.Shared.DataAccess.UoW.Abstractions
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        bool Any(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity obj);
        TEntity Update(TEntity obj);
        void Delete(object id);
        bool Contains(TEntity entity);

        Task<TEntity> AddAsync(TEntity obj);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> obj);
        Task DeleteAsync(object id);
        void Delete(TEntity obj);
        void DeleteRange(IEnumerable<TEntity> obj);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindBy<T2>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, T2>>[] paths);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllAsNoTracking();

        TEntity GetById(object id);
        void Detach(TEntity obj);

        Task InsertBulkAsync(IList<TEntity> entities);
    }
}
