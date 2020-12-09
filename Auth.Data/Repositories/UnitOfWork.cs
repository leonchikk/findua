using Services.Shared.DataAccess.UoW.Implementations;

namespace Auth.Data.Repositories
{
    public class UnitOfWork : BaseUnitOfWork<AuthContext>
    {
        public UnitOfWork(AuthContext dbContext) : base(dbContext)
        {

        }
    }
}
