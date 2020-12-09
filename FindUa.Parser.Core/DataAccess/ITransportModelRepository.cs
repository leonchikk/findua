using FindUa.Parser.Core.Entities;
using Services.Shared.DataAccess.UoW.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Core.DataAccess
{
    public interface ITransportModelRepository : IBaseRepository<TransportModel>
    {
        TransportModel Create(string modelName, int brandId);
        Task<IList<TransportModel>> LoadAllAsyncAsNoTracking();
    }
}
