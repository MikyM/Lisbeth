using Lisbeth.API.DataAccessLayer.Interfaces.Repositories;
using MikyM.Common.DataAccessLayer.Repositories;

namespace Lisbeth.API.DataAccessLayer.Repositories
{
    public class EnvironmentRepository : Repository<Domain.Entities.AggregateRootEntities.Environment>, IEnvironmentRepository
    {
        public EnvironmentRepository(Microsoft.EntityFrameworkCore.DbContext ctx) : base(ctx)
        {
            
        }
    }
}
