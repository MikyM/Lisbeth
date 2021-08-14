using System.Collections.Generic;
using MikyM.Common.Domain.Entities;

namespace Lisbeth.API.Domain.Entities.AggregateRootEntities
{
    public class Project : AggregateRootEntity
    {
        public string Name { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Bug> Bugs { get; set; }
        public long EnvironmentId { get; set; }
        public Environment Environment { get; set; }
    }
}
