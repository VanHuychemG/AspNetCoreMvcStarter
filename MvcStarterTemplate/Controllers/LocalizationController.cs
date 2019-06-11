using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;

namespace MvcStarterTemplate.Controllers
{
    public class LocalizationController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ViewData["culture"] = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            ViewData["controller"] = ControllerContext.ActionDescriptor.ControllerName;
            ViewData["action"] = ControllerContext.ActionDescriptor.ActionName;
        }
    }
}
