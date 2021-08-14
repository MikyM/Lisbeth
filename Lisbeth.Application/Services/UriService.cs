using Lisbeth.API.Application.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using MikyM.Common.DataAccessLayer.Filters;
using System;

namespace Lisbeth.API.Application.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPageUri(PaginationFilter filter, string route)
        {
            Uri endpointUri = new(string.Concat(_baseUri, route));
            string modifiedUri =
                QueryHelpers.AddQueryString(endpointUri.ToString(), "pageNumber", filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
