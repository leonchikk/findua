using FindUa.Parser.Core.Entities;
using Services.Shared.DataAccess.UoW.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Core.DataAccess
{
    public interface ICityRepository : IBaseRepository<City>
    {
        Task<IList<City>> LoadAllAsyncAsNoTracking();
    }
}
