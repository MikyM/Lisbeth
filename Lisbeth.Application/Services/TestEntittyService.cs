using AutoMapper;
using Lisbeth.API.Application.Interfaces;
using Lisbeth.API.DataAccessLayer.DbContext;
using Lisbeth.API.Domain.DTOs;
using Lisbeth.API.Domain.Entities;
using MikyM.Common.Application.Services;
using MikyM.Common.DataAccessLayer.UnitOfWork;

namespace Lisbeth.API.Application.Services
{
    public class TestEntityService : CrudService<TestEntity, LisbethDbContext>, ITestEntityService
    {
        public TestEntityService(IMapper mapper, IUnitOfWork<LisbethDbContext> uof) : base(mapper, uof)
        {
            
        }
    }
}
