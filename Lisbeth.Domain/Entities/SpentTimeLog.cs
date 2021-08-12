using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.Domain.Entities
{
    public class SpentTimeLog : Entity
    {
        public float TimeAmount { get; set; }
        public TimeType TimeType { get; set; }
        public SpentTimeType Type { get; set; }
    }
}
