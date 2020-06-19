using System.Collections.Generic;
using System.Threading.Tasks;
using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.Parser.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FindUa.Parser.Data.Repositories
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
