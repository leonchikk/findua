using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Data.Repositories
{
    public class TransportModelRepository : BaseRepository<TransportModel>, ITransportModelRepository
    {
        public TransportModelRepository(TransportParserContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<TransportModel>> LoadAllAsync()
        {
            return await DbSet.Include(model => model.Brand)
                              .ThenInclude(brand => brand.VehicleType)
                              .ToListAsync();
        }
    }
}
