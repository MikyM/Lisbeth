using System;
using Lisbeth.API.Domain.DTOs.Base;

namespace Lisbeth.API.Domain.DTOs
{
    public class ResponseTestDto : TestDto
    {
        public long Id { get; }
        public bool IsEnabled { get; set; }
        public DateTime? CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
    }
}
