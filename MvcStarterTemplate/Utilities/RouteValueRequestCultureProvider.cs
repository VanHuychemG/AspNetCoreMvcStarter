using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStarterTemplate.Utilities
{
    public class RouteValueRequestCultureProvider : IRequestCultureProvider
    {
        private readonly IList<CultureInfo> _cultures;
        private readonly string _defaultCulture;

        public RouteValueRequestCultureProvider(IList<CultureInfo> cultures, string defaultCulture)
        {
            _cultures = cultures;
            _defaultCulture = defaultCulture;
        }

        /// <inheritdoc />
        public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            var path = httpContext.Request.Path;

            if (string.IsNullOrWhiteSpace(path))
                return Task.FromResult(new ProviderCultureResult(_defaultCulture));

            var routeValues = httpContext.Request.Path.Value.Split('/');
            if (routeValues.Length <= 1)
                return Task.FromResult(new ProviderCultureResult(_defaultCulture));

            return Task.FromResult(_cultures.All(x => !string.Equals(x.Name.ToLower(), routeValues[1].ToLower(), StringComparison.InvariantCultureIgnoreCase))
                ? new ProviderCultureResult(_defaultCulture)
                : new ProviderCultureResult(routeValues[1]));
        }
    }
}
