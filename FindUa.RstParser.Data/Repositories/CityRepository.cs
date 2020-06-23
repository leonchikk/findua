using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.RstParser.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.RstParser.Data.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(TransportParserContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<City>> LoadAllAsyncAsNoTracking()
        {
            return await DbSet.Include(city => city.Region)
                              .ThenInclude(region => region.Country)
                              .AsNoTracking()
                              .ToListAsync();
        }
    }
}
