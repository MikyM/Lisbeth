using System;

namespace Lisbeth.Domain.DTOs.Base
{
    public interface IResponseDto : IDto
    {
        public long Id { get; }
        public DateTime? CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
    }
}
