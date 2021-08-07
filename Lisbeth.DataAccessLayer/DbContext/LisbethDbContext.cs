using Microsoft.EntityFrameworkCore;

namespace Lisbeth.DataAccessLayer.DbContext
{
    public class LisbethDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public LisbethDbContext(DbContextOptions<LisbethDbContext> options) : base(options)
        {
        }
    }
}
