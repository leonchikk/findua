using Common.Core.Interfaces;
using FindUa.Parser.Data.Contexts;
using System;
using System.Threading.Tasks;

namespace FindUa.Parser.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TransportParserContext _dbContext;

        public UnitOfWork
        (
            TransportParserContext dbContext
        )
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
