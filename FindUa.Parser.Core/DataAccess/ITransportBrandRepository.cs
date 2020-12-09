using FindUa.Parser.Core.Entities;
using Services.Shared.DataAccess.UoW.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Core.DataAccess
{
    public interface ITransportBrandRepository : IBaseRepository<TransportBrand>
    {
        TransportBrand Create(string brandName, int vehicleTypeId);
        Task<IList<TransportBrand>> LoadAllAsyncAsNoTracking();
    }
}
