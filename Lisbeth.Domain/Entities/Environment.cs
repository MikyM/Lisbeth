using Lisbeth.Domain.Entities.Base;
using System.Collections.Generic;

namespace Lisbeth.Domain.Entities
{
    public class Environment : Entity
    {
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
        public List<Queue> Queues { get; set; }
        public User CreatedBy { get; set; }
    }
}
