using Lisbeth.API.DataAccessLayer.DbContext;
using Lisbeth.API.DataAccessLayer.Interfaces.Repositories;
using Lisbeth.API.Domain.Entities.EnvironmentSpecificEntities;
using MikyM.Common.DataAccessLayer.Repositories;

namespace Lisbeth.API.DataAccessLayer.Repositories
{
    public class TrackerRepository : Repository<Tracker>, ITrackerRepository
    {
        public TrackerRepository(LisbethDbContext ctx) : base(ctx)
        {
        }
    }
}

