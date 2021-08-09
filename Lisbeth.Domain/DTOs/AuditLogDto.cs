using System;
using Lisbeth.Domain.DTOs.Base;

namespace Lisbeth.Domain.DTOs
{
    public class AuditLogDto : IResponseDto
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
