using AutoMapper;
using Lisbeth.DataAccessLayer.UnitOfWork;
using Lisbeth.Shared.Application.Interfaces.Base;
using System;
using System.Threading.Tasks;

namespace Lisbeth.Shared.Application.Services.Base
{
    public class ServiceBase : IServiceBase
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public ServiceBase(IMapper mapper, IUnitOfWork uof)
        {
            _mapper = mapper;
            _unitOfWork = uof;
        }

        public virtual async Task<int> CommitAsync()
        {
            return await _unitOfWork.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _unitOfWork.RollbackAsync();
        }

        public async Task BeginAsync()
        {
            await _unitOfWork.UseTransaction();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
                // get rid of managed resources
            }
            // get rid of unmanaged resources
        }
    }
}
