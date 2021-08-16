using Lisbeth.API.Domain.DTOs.Base;

namespace Lisbeth.API.Domain.DTOs.RequestDtos
{
    public class EnvironmentReqDto : RequestDto
    {
        public string Name { get; set; }
        public string OwnerId { get; set; }
    }
}
