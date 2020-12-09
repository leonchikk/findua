using Microsoft.EntityFrameworkCore;
using Services.Shared.DataAccess.UoW.Abstractions;
using System;
using System.Threading.Tasks;

namespace Services.Shared.DataAccess.UoW.Implementations
{
    public class BaseUnitOfWork<TContext>: IBaseUnitOfWork where TContext: DbContext
    {
        protected readonly TContext _dbContext;

        public BaseUnitOfWork(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
