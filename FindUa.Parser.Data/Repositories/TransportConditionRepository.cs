using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Data.Repositories
{
    public class TransportConditionRepository : BaseRepository<TransportCondition>, ITransportConditionRepository
    {
        public TransportConditionRepository(TransportParserContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<TransportCondition>> LoadAllAsync()
        {
            return await DbSet.ToListAsync();
        }
    }
}
