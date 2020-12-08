using Common.Core.Interfaces;
using Common.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Auth.Data.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly AuthContext _dbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(AuthContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public TEntity Add(TEntity obj)
        {
            DbSet.Add(obj);
            return obj;
        }

        public async Task<TEntity> AddAsync(TEntity obj)
        {
            await DbSet.AddAsync(obj);
            return obj;
        }

        public void Delete(TKey id)
        {
            TEntity obj = DbSet.First(x => x.Id == id);
            DbSet.Remove(obj);
        }

        public async Task DeleteAsync(Guid id)
        {
            TEntity obj = await DbSet.FirstAsync(x => x.Id == id);
            DbSet.Remove(obj);
        }

        public bool Contains(TEntity entity)
        {
            return DbSet.FirstOrDefault(t => t == entity) != null;
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<TEntity> FindBy<T2>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, T2>>[] paths)
        {
            foreach (Expression<Func<TEntity, T2>> path in paths)
            {
                DbSet.Include(path);
            }

            return DbSet.Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public TEntity Update(TEntity obj)
        {
            DbSet.Update(obj);
            return obj;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> obj)
        {
            await DbSet.AddRangeAsync(obj);
            return obj;
        }

        public void Delete(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public void DeleteRange(IEnumerable<TEntity> obj)
        {
            DbSet.RemoveRange(obj);
        }

        public IQueryable<TEntity> GetAllWithIncludies(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = DbSet.AsQueryable();
            foreach (Expression<Func<TEntity, object>> include in includeProperties)
            {
                query = query.Include(include);
            }

            return query;
        }

        public TEntity GetByIdWithIncludies(Guid id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = DbSet.Where(x => x.Id == id);
            foreach (Expression<Func<TEntity, object>> include in includeProperties)
            {
                query = query.Include(include);
            }

            return query.FirstOrDefault();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }
    }
}
