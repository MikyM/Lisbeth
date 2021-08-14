using Lisbeth.API.DataAccessLayer.Interfaces.Repositories;
using Lisbeth.API.Domain.Entities;
using MikyM.Common.DataAccessLayer.Repositories;

namespace Lisbeth.API.DataAccessLayer.Repositories
{
    public class TestEntityRepository : Repository<TestEntity>, ITestEntityRepository
    {
        public TestEntityRepository(Microsoft.EntityFrameworkCore.DbContext ctx) : base(ctx)
        {
            
        }
    }
}
