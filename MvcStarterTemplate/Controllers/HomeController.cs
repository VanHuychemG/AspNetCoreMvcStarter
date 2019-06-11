using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using MvcStarterTemplate.Models;
using System.Diagnostics;
using System.Linq;

namespace MvcStarterTemplate.Controllers
{
    public class HomeController : LocalizationController
    {
        private readonly IStringLocalizer<HomeController> _stringLocalizer;
        private readonly IOptions<RequestLocalizationOptions> _localizationOptions;

        private string _currentLanguage;

        private string CurrentLanguage
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentLanguage))
                    return _currentLanguage;

                if (!string.IsNullOrEmpty(_currentLanguage))
                    return _currentLanguage;

                var feature = HttpContext.Features.Get<IRequestCultureFeature>();
                _currentLanguage = feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLowerInvariant();

                return _currentLanguage;
            }
        }

        public HomeController(
            IStringLocalizer<HomeController> stringLocalizer,
            IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _stringLocalizer = stringLocalizer;
            _localizationOptions = localizationOptions;
            _stringLocalizer = stringLocalizer;
            _localizationOptions = localizationOptions;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult RedirectToDefaultCulture()
        {
            var culture = CurrentLanguage;

            var cultureItems = _localizationOptions.Value.SupportedUICultures
                .Select(x => x.TwoLetterISOLanguageName.ToLowerInvariant())
                .ToList();
            if (!cultureItems.Contains(culture))
                culture = "nl";

            return RedirectToAction("Index", new { culture });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
