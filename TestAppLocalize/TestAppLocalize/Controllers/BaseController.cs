using System.Globalization;
using System.Threading;
using System.Web.Mvc;
namespace TestAppLocalize.Controllers
{
  public class BaseController : Controller
  {
    protected override void OnActionExecuting(
        ActionExecutingContext filterContext)
    {
      //string culture = filterContext.RouteData.Values["language"]?.ToString()
      //                    ?? "pl-PL";
      object cultureParam = null;

      filterContext.ActionParameters.TryGetValue("culture", out cultureParam).ToString();
      var culture = "pl-PL";
      if (cultureParam != null) { 
        culture = cultureParam as string;
      }

      filterContext.ActionParameters["language"] = culture;
      var cultureInfo = CultureInfo.GetCultureInfo(culture);
      Thread.CurrentThread.CurrentCulture = cultureInfo;
      Thread.CurrentThread.CurrentUICulture = cultureInfo;
      base.OnActionExecuting(filterContext);
    }
    public ActionResult RedirectToLocalized()
    {
      return RedirectPermanent("/pl-PL");
    }
  }
}