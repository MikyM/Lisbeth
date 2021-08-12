using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.Domain.Entities
{
    public class Status : Entity
    {
        public string Name { get; set; }
        public long QueueId { get; set; }
        public Queue Queue { get; set; }
    }
}
