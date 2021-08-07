using Lisbeth.DataAccessLayer.Interfaces.Base;
using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.DataAccessLayer.Repositories.Base
{
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity> where TEntity : Entity
    {
        
    }
}
