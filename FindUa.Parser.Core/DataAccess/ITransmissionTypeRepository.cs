using FindUa.Parser.Core.Entities;
using Services.Shared.DataAccess.UoW.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Core.DataAccess
{
    public interface ITransmissionTypeRepository : IBaseRepository<TransmissionType>
    {
        Task<IList<TransmissionType>> LoadAllAsyncAsNoTracking();
    }
}
