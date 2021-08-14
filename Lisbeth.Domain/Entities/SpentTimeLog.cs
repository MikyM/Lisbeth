using Lisbeth.API.Domain.Entities.EnvironmentSpecificEntities;
using MikyM.Common.Domain.Entities;

namespace Lisbeth.API.Domain.Entities
{
    public class SpentTimeLog : Entity
    {
        public float TimeAmount { get; set; } //default hours
        public long? SpentTimeTypeId { get; set; }
        public SpentTimeType SpentTimeType { get; set; }
    }
}
