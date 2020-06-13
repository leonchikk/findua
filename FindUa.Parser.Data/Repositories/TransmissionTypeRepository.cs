using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Data.Repositories
{
    public class TransmissionTypeRepository : BaseRepository<TransmissionType>, ITransmissionTypeRepository
    {
        public TransmissionTypeRepository(TransportParserContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<TransmissionType>> LoadAllAsync()
        {
            return await DbSet.ToListAsync();
        }
    }
}
