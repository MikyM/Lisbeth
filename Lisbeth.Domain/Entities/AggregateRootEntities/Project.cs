using System.Collections.Generic;
using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.Domain.Entities.AggregateRootEntities
{
    public class Project : RepositoryEntity, IAggregateRootEntity
    {
        public string Name { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Bug> Bugs { get; set; }
        public long? EnvironmentId { get; set; }
        public Environment Environment { get; set; }
    }
}
