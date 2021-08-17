using AutoMapper;
using Lisbeth.API.Application.Interfaces;
using Lisbeth.API.DataAccessLayer.DbContext;
using Lisbeth.API.Domain.Entities.EnvironmentSpecificEntities;
using MikyM.Common.Application.Services;
using MikyM.Common.DataAccessLayer.UnitOfWork;

namespace Lisbeth.API.Application.Services
{
    public class StatusService : CrudService<Status, LisbethDbContext>, IStatusService
    {
        public StatusService(IMapper mapper, IUnitOfWork<LisbethDbContext> ctx) : base(mapper, ctx)
        {

        }
    }
}