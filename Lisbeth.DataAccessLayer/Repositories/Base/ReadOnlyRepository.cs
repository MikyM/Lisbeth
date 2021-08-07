using Lisbeth.DataAccessLayer.Interfaces.Base;
using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.DataAccessLayer.Repositories.Base
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        
    }
}
