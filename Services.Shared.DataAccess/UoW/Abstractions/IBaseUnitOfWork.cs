using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Services.Shared.DataAccess.UoW.Abstractions
{
    public interface IBaseUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
