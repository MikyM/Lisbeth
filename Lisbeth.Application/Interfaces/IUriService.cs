using Lisbeth.DataAccessLayer.Filters;
using System;

namespace Lisbeth.API.Application.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
