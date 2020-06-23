using Common.Core.Interfaces;
using FindUa.RstParser.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Core.DataAccess
{
    public interface ITransportConditionRepository : IRepository<TransportCondition>
    {
        Task<IList<TransportCondition>> LoadAllAsyncAsNoTracking();
    }
}
