using FindUa.RstParser.Core.Entities;
using Services.Shared.DataAccess.UoW.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Core.DataAccess
{
    public interface ITransportConditionRepository : IBaseRepository<TransportCondition>
    {
        Task<IList<TransportCondition>> LoadAllAsyncAsNoTracking();
    }
}
