using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.DataAccessLayer.Interfaces.Base
{
    public interface IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        
    }
}
