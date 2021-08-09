using System;
using Lisbeth.Domain.DTOs.Base;

namespace Lisbeth.Domain.DTOs
{
    public class ResponseTestDto : TestDto, IResponseDto
    {
        public long Id { get; }
        public DateTime? CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
    }
}
