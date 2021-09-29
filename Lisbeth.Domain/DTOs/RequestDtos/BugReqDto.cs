using System;
using Lisbeth.API.Domain.DTOs.Base;
using Lisbeth.API.Domain.Entities;
using System.Collections.Generic;

namespace Lisbeth.API.Domain.DTOs.RequestDtos
{
    public class BugReqDto : RequestDto
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public long TrackerId { get; set; }
        public List<Uri> Attachments { get; set; }
        public long AssignedToId { get; set; }
        public long CreatedById { get; set; }
        public long ProjectId { get; set; }
    }
}
