using Lisbeth.API.DataAccessLayer.DbContext;
using Lisbeth.API.DataAccessLayer.Interfaces.Repositories;
using Lisbeth.API.Domain.Entities.AggregateRootEntities;
using MikyM.Common.DataAccessLayer.Repositories;

namespace Lisbeth.API.DataAccessLayer.Repositories
{
    public class EnvironmentRepository : Repository<Environment>, IEnvironmentRepository
    {
        public EnvironmentRepository(LisbethDbContext ctx) : base(ctx)
        {
            
        }
    }
}
