using AutoMapper;
using Lisbeth.API.Application.Interfaces;
using Lisbeth.API.DataAccessLayer.DbContext;
using Lisbeth.API.Domain.Entities.EnvironmentSpecificEntities;
using MikyM.Common.Application.Services;
using MikyM.Common.DataAccessLayer.UnitOfWork;

namespace Lisbeth.API.Application.Services
{
    public class TrackerService : CrudService<Tracker, LisbethDbContext>, ITrackerService
    {
        public TrackerService(IMapper mapper, IUnitOfWork<LisbethDbContext> ctx) : base(mapper, ctx)
        {

        }
    }
}