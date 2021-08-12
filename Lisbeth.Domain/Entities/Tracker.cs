using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.Domain.Entities
{
    public class Tracker : Entity
    {
        public string Name { get; set; }
        public long? EnvironmentId { get; set; }
        public Environment Environment { get; set; }
    }
}
