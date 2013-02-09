using System.Web;
using System.Web.Mvc;

namespace Atay.ASPNetMVC4Samples.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}