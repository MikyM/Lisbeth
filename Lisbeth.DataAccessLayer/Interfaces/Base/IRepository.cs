using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.DataAccessLayer.Interfaces.Base
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        
    }
}
