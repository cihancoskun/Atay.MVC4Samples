using System.Web.Mvc;
using System.Web.WebPages;

namespace Atay.ASPNetMVC4Samples.Web.Controllers
{
    public class ViewSwitcherControllerController : Controller
    {
        public RedirectResult SwitchView(bool mobile, string returnUrl)
        {
            if (Request.Browser.IsMobileDevice == mobile)
                HttpContext.ClearOverriddenBrowser();
            else
                HttpContext.SetOverriddenBrowser(mobile ? BrowserOverride.Mobile : BrowserOverride.Desktop);

            return Redirect(returnUrl);
        }
    }
}
