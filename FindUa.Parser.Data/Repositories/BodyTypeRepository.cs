using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Data.Repositories
{
    public class BodyTypeRepository : BaseRepository<BodyType>, IBodyTypeRepository
    {
        public BodyTypeRepository(TransportParserContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<BodyType>> LoadAllAsync()
        {
            return await DbSet.Include(x => x.VehicleType).ToListAsync();
        }
    }
}
