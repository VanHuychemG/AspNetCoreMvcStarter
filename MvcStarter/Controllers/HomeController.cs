using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MvcStarter.Models;
using System.Diagnostics;

namespace MvcStarter.Controllers
{
    public class HomeController : LocalizationController
    {
        private readonly IStringLocalizer<HomeController> _localizer;

        public ActionResult RedirectToDefaultCulture()
        {
            const string culture = "nl";

            return RedirectToAction("Index", new { culture });
        }

        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
