using System.Collections.Generic;
using Lisbeth.Domain.Entities.Base;
using Lisbeth.Domain.Entities.EnvironmentSpecificEntities;

namespace Lisbeth.Domain.Entities.AggregateRootEntities
{
    public class Queue : RepositoryEntity, IAggregateRootEntity
    {
        public string Name { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Status> Statuses { get; set; }
        public long EnvironmentId { get; set; }
        public Environment Environment { get; set; }
    }
}
