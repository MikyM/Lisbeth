using System.Collections.Generic;
using Lisbeth.Domain.Entities.AggregateRootEntities;
using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.Domain.Entities.EnvironmentSpecificEntities
{
    public class Status : RepositoryEntity, IEnvironmentSpecificEntity
    {
        public string Name { get; set; }
        public long QueueId { get; set; }
        public Queue Queue { get; set; }
        public List<Status> AvailableStatuses { get; set; }
    }
}
