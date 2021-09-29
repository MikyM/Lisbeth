using Lisbeth.API.Domain.DTOs.Base;
using System;
using System.Collections.Generic;

namespace Lisbeth.API.Domain.DTOs.ResponseDtos
{
    public class BugResDto : ResponseDto
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public long TrackerId { get; set; }
        public long StatusId { get; set; }
        public List<TicketHistoryLogResDto> History { get; set; }
        public List<Uri> Attachments { get; set; }
        public List<CommentResDto> Comments { get; set; }
        public long AssignedToId { get; set; }
        public long CreatedById { get; set; }
        public long ProjectId { get; set; }
    }
}
