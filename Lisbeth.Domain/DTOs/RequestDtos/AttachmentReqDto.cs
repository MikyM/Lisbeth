using Lisbeth.API.Domain.DTOs.Base;
using System;

namespace Lisbeth.API.Domain.DTOs.RequestDtos
{
    public class AttachmentReqDto : RequestDto
    {
        public Uri Uri { get; set; }
        public long? CommentId { get; set; }
        public long? TicketId { get; set; }
        public long? BugId { get; set; }
    }
}
