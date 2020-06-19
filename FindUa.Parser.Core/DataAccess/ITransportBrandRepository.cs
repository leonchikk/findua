using Common.Core.Interfaces;
using FindUa.Parser.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Core.DataAccess
{
    public interface ITransportBrandRepository : IRepository<TransportBrand>
    {
        TransportBrand Create(string brandName, int vehicleTypeId);
        Task<IList<TransportBrand>> LoadAllAsyncAsNoTracking();
    }
}
