using Lisbeth.API.DataAccessLayer.DbContext;
using Lisbeth.API.DataAccessLayer.Interfaces.Repositories;
using Lisbeth.API.Domain.Entities;
using MikyM.Common.DataAccessLayer.Repositories;

namespace Lisbeth.API.DataAccessLayer.Repositories
{
    public class AuditRepository : ReadOnlyRepository<AuditLog>, IAuditRepository
    {
        public AuditRepository(LisbethDbContext ctx) : base(ctx)
        {
            
        }
    }
}
