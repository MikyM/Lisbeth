using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.Domain.Entities
{
    public class AuditLog : Entity
    {
        public string TableName { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}
