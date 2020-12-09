using Services.Shared.DataAccess.UoW.Implementations;

namespace Auth.Data.Repositories
{
    public class Repository<TEntity> : BaseRepository<TEntity> where TEntity : class
    {
        public Repository(AuthContext dbContext) : base(dbContext)
        {
        }
    }
}
