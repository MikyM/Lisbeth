using System;

namespace Lisbeth.Domain.DTOs.Base
{
    public abstract class Dto
    {
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
    }
}
