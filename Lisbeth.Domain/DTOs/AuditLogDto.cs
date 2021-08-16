using System;
using Lisbeth.API.Domain.DTOs.Base;

namespace Lisbeth.API.Domain.DTOs
{
    public class AuditLogDto : Dto
    {
        public long Id { get; }
        public string TableName { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public DateTime? CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
    }
}
