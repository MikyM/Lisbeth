using Lisbeth.API.Domain.Entities.AggregateRootEntities;
using MikyM.Common.Domain.Entities;

namespace Lisbeth.API.Domain.Entities.EnvironmentSpecificEntities
{
    public class Tracker : EnvironmentSpecificEntity
    {
        public string Name { get; set; }
        public long? EnvironmentId { get; set; }
        public Environment Environment { get; set; }
    }
}
