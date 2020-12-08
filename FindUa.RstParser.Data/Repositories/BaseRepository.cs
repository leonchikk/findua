using Common.Core.Interfaces;
using EFCore.BulkExtensions;
using FindUa.RstParser.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FindUa.RstParser.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly TransportParserContext _dbContext;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(TransportParserContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<T>();
        }

        public T Add(T obj)
        {
            DbSet.Add(obj);
            return obj;
        }

        public async Task<T> AddAsync(T obj)
        {
            await DbSet.AddAsync(obj);
            return obj;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> obj)
        {
            await DbSet.AddRangeAsync(obj);
            return obj;
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public bool Contains(T entity)
        {
            return DbSet.FirstOrDefault(t => t == entity) != null;
        }

        public void Delete(int id)
        {
            T obj = DbSet.Find(id);
            DbSet.Remove(obj);
        }

        public void Delete(T obj)
        {
            DbSet.Remove(obj);
        }

        public async Task DeleteAsync(int id)
        {
            T obj = await DbSet.FindAsync(id);
            DbSet.Remove(obj);
        }

        public void DeleteRange(IEnumerable<T> obj)
        {
            DbSet.RemoveRange(obj);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<T> FindBy<T2>(Expression<Func<T, bool>> predicate, params Expression<Func<T, T2>>[] paths)
        {
            foreach (Expression<Func<T, T2>> path in paths)
            {
                DbSet.Include(path);
            }

            return DbSet.Where(predicate);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<T> GetAllAsNoTracking()
        {
            return DbSet.AsQueryable().AsNoTracking();
        }

        public IQueryable<T> GetAllWithIncludies(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbSet.AsQueryable();
            foreach (Expression<Func<T, object>> include in includeProperties)
            {
                query = query.Include(include);
            }

            return query;
        }

        public IQueryable<T> GetAllWithIncludiesAsNoTracking(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbSet.AsQueryable().AsNoTracking();
            foreach (Expression<Func<T, object>> include in includeProperties)
            {
                query = query.Include(include);
            }

            return query;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public T Update(T obj)
        {
            DbSet.Update(obj);
            return obj;
        }

        public async Task InsertBulkAsync(IList<T> entities)
        {
            await _dbContext.BulkInsertAsync(entities);
        }

        public void Detach(T obj)
        {
            _dbContext.Entry(obj).State = EntityState.Detached;
        }
    }
}
