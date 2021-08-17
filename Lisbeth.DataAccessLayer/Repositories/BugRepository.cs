using Lisbeth.API.DataAccessLayer.DbContext;
using Lisbeth.API.DataAccessLayer.Interfaces.Repositories;
using Lisbeth.API.Domain.Entities.AggregateRootEntities;
using MikyM.Common.DataAccessLayer.Repositories;

namespace Lisbeth.API.DataAccessLayer.Repositories
{
    public class BugRepository : Repository<Bug>, IBugRepository
    {
        public BugRepository(LisbethDbContext ctx) : base(ctx)
        {
        }
    }
}
