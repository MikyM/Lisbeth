using System.Collections.Generic;
using Lisbeth.API.Domain.Entities.EnvironmentSpecificEntities;
using MikyM.Common.Domain.Entities;

namespace Lisbeth.API.Domain.Entities.AggregateRootEntities
{
    public class Queue : AggregateRootEntity
    {
        public string Name { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Status> Statuses { get; set; }
        public long EnvironmentId { get; set; }
        public Environment Environment { get; set; }
    }
}
