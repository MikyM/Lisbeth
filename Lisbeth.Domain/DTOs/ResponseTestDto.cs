using System;
using Lisbeth.API.Domain.DTOs.Base;

namespace Lisbeth.API.Domain.DTOs
{
    public class ResponseTestDto : TestDto, IResponseDto
    {
        public long Id { get; }
        public DateTime? CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
    }
}
