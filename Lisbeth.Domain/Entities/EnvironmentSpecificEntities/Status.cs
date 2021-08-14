using System.Collections.Generic;
using Lisbeth.API.Domain.Entities.AggregateRootEntities;
using MikyM.Common.Domain.Entities;

namespace Lisbeth.API.Domain.Entities.EnvironmentSpecificEntities
{
    public class Status : EnvironmentSpecificEntity
    {
        public string Name { get; set; }
        public long QueueId { get; set; }
        public Queue Queue { get; set; }
        public List<Status> AvailableStatuses { get; set; }
    }
}
