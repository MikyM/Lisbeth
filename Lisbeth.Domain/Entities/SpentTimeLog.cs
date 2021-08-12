using Lisbeth.Domain.Entities.Base;
using Lisbeth.Domain.Entities.EnvironmentSpecificEntities;

namespace Lisbeth.Domain.Entities
{
    public class SpentTimeLog : Entity
    {
        public float TimeAmount { get; set; } //default hours
        public long? SpentTimeTypeId { get; set; }
        public SpentTimeType SpentTimeType { get; set; }
    }
}
