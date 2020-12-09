using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.RstParser.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.Shared.DataAccess.UoW.Implementations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.RstParser.Data.Repositories
{
    public class BodyTypeRepository : BaseRepository<BodyType>, IBodyTypeRepository
    {
        public BodyTypeRepository(TransportParserContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<BodyType>> LoadAllAsyncAsNoTracking()
        {
            return await DbSet.Include(x => x.VehicleType)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
