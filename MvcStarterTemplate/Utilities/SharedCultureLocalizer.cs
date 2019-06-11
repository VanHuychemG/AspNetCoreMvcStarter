using Microsoft.Extensions.Localization;
using MvcStarterTemplate.Resources;
using System.Reflection;

namespace MvcStarterTemplate.Utilities
{
    public class SharedCultureLocalizer
    {
        private readonly IStringLocalizer _localizer;

        public SharedCultureLocalizer(IStringLocalizerFactory factory)
        {
            var type = typeof(ViewResources);

            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);

            _localizer = factory.Create("ViewResources", assemblyName.Name);
        }

        // if we have formatted string we can provide arguments
        // e.g.: @Localizer.Text("Hello {0}", User.Name)
        public LocalizedString Text(
            string key,
            params object[] arguments)
        {
            return arguments == null
                ? _localizer[key]
                : _localizer[key, arguments];
        }
    }
}
