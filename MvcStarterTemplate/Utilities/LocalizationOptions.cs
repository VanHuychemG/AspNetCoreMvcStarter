using Microsoft.AspNetCore.Builder;
using System;

namespace MvcStarterTemplate.Utilities
{
    public class LocalizationOptions
    {
        public Action<RequestLocalizationOptions> RequestLocalizationOptions { get; set; }

        public string ResourcesPath { get; set; } = "";
    }
}
