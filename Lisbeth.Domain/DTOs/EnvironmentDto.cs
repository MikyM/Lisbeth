using System.Collections.Generic;
using Lisbeth.API.Domain.DTOs.Base;
using Lisbeth.API.Domain.Entities.AggregateRootEntities;
using Lisbeth.API.Domain.Entities.EnvironmentSpecificEntities;

namespace Lisbeth.API.Domain.DTOs
{
    public class EnvironmentDto : Dto
    {
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
        public List<Queue> Queues { get; set; }
        public List<Tracker> Trackers { get; set; }
        public string OwnerId { get; set; }
    }
}
