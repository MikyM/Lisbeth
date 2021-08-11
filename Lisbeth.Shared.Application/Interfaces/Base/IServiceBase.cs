using System;
using System.Threading.Tasks;

namespace Lisbeth.Shared.Application.Interfaces.Base
{
    public interface IServiceBase : IDisposable
    {
        Task<int> CommitAsync();
        Task RollbackAsync();
        Task BeginAsync();
    }
}
