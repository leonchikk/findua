using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.RstParser.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.RstParser.Data.Repositories
{
    public class TransmissionTypeRepository : BaseRepository<TransmissionType>, ITransmissionTypeRepository
    {
        public TransmissionTypeRepository(TransportParserContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<TransmissionType>> LoadAllAsyncAsNoTracking()
        {
            return await DbSet.AsNoTracking()
                              .ToListAsync();
        }
    }
}
