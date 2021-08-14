using System.Collections.Generic;
using Lisbeth.API.Domain.Entities.EnvironmentSpecificEntities;
using MikyM.Common.Domain.Entities;

namespace Lisbeth.API.Domain.Entities.AggregateRootEntities
{
    public class Environment : AggregateRootEntity
    {
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
        public List<Queue> Queues { get; set; }
        public List<Tracker> Trackers { get; set; }
        public User CreatedBy { get; set; }
    }
}
