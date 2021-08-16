using System;

namespace Lisbeth.API.Domain.DTOs.Base
{
    public abstract class ResponseDto : Dto
    {
        public long Id { get; set; }
        public bool IsDisabled { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
