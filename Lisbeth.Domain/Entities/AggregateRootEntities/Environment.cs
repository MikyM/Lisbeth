using System.Collections.Generic;
using Lisbeth.Domain.Entities.Base;
using Lisbeth.Domain.Entities.EnvironmentSpecificEntities;

namespace Lisbeth.Domain.Entities.AggregateRootEntities
{
    public class Environment : RepositoryEntity, IAggregateRootEntity
    {
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
        public List<Queue> Queues { get; set; }
        public List<Tracker> Trackers { get; set; }
        public User CreatedBy { get; set; }
    }
}
