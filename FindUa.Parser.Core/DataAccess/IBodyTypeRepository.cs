using Common.Core.Interfaces;
using FindUa.Parser.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Core.DataAccess
{
    public interface IBodyTypeRepository : IRepository<BodyType>
    {
        Task<IList<BodyType>> LoadAllAsyncAsNoTracking();
    }
}
