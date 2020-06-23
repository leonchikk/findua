using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.RstParser.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.RstParser.Data.Repositories
{
    public class TransportModelRepository : BaseRepository<TransportModel>, ITransportModelRepository
    {
        public TransportModelRepository(TransportParserContext dbContext) : base(dbContext)
        {
        }

        public TransportModel Create(string modelName, int brandId)
        {
            var model = new TransportModel()
            {
                BrandId = brandId,
                Name = modelName
            };

            DbSet.Add(model);

            return model;
        }

        public async Task<IList<TransportModel>> LoadAllAsyncAsNoTracking()
        {
            return await DbSet.Include(model => model.Brand)
                              .ThenInclude(brand => brand.VehicleType)
                              .AsNoTracking()
                              .ToListAsync();
        }
    }
}
