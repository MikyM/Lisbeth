using Lisbeth.Domain.Entities.AggregateRootEntities;
using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.Domain.Entities.EnvironmentSpecificEntities
{
    public class Tracker : RepositoryEntity, IEnvironmentSpecificEntity
    {
        public string Name { get; set; }
        public long? EnvironmentId { get; set; }
        public Environment Environment { get; set; }
    }
}
