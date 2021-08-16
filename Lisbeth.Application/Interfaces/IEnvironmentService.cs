using Lisbeth.API.Domain.DTOs;
using MikyM.Common.Application.Interfaces;

namespace Lisbeth.API.Application.Interfaces
{
    public interface IEnvironmentService : ICrudService<Domain.Entities.AggregateRootEntities.Environment, EnvironmentDto>
    {
        
    }
}
