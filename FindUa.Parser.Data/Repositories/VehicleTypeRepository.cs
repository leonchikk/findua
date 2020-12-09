using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Services.Shared.DataAccess.UoW.Implementations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.RstParser.Data.Repositories
{
    public class VehicleTypeRepository : BaseRepository<VehicleType>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(TransportParserContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<VehicleType>> LoadAllAsyncAsNoTracking()
        {
            return await DbSet.AsNoTracking()
                              .ToListAsync();
        }
    }
}
