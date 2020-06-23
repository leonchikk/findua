using EFCore.BulkExtensions;
using FindUa.Parser.Core.DataAccess;
using FindUa.Parser.Core.Entities;
using FindUa.RstParser.Data.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.RstParser.Data.Repositories
{
    public class TransportSaleAnnounceRepository : BaseRepository<TransportSaleAnnounce>, ITransportSaleAnnounceRepository
    {
        public TransportSaleAnnounceRepository(TransportParserContext dbContext) : base(dbContext)
        {
        }

        public async Task InsertRangeSaleAnnounces(IList<TransportSaleAnnounce> saleAnnounces)
        {
            var carConditions = new List<TransportConditionInSaleAnnounce>();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                var bulkConfig = new BulkConfig { PreserveInsertOrder = true, SetOutputIdentity = true };
                await _dbContext.BulkInsertAsync(saleAnnounces, bulkConfig);
                foreach (var saleAnnounce in saleAnnounces)
                {
                    foreach (var transportCondition in saleAnnounce.TransportConditions)
                    {
                        transportCondition.SaleAnnounceId = saleAnnounce.Id;
                    }
                    carConditions.AddRange(saleAnnounce.TransportConditions);
                }
                await _dbContext.BulkInsertAsync(carConditions);
                transaction.Commit();
            }
        }
    }
}
