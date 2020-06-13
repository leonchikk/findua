using Common.Core.Interfaces;
using FindUa.Parser.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindUa.Parser.Core.DataAccess
{
    public interface ICityRepository : IRepository<City>
    {
        Task<IList<City>> LoadAllAsync();
    }
}
