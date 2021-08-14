using Lisbeth.API.Domain.Entities;
using MikyM.Common.DataAccessLayer.Repositories;

namespace Lisbeth.API.DataAccessLayer.Interfaces.Repositories
{
    public interface IAuditRepository : IReadOnlyRepository<AuditLog>
    {
        
    }
}
