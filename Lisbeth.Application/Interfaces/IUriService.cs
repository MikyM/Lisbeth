using System;
using MikyM.Common.DataAccessLayer.Filters;

namespace Lisbeth.API.Application.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
