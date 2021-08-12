using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.Domain.Entities
{
    public class SpentTimeLog : Entity
    {
        public float TimeAmount { get; set; }
        public long? TimeTypeId { get; set; }
        public TimeType TimeType { get; set; }
        public long? SpentTimeTypeId { get; set; }
        public SpentTimeType SpentTimeType { get; set; }
    }
}
