using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Atay.ASPNetMVC4Samples.Web.Controllers;

using Microsoft.Practices.Unity;

namespace Atay.ASPNetMVC4Samples.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //DisplayModes.Modes.Insert(0, new DefaultDisplayMode("iPhone")
            //{
            //    ContextCondition = (context => context.Request.UserAgent.IndexOf
            //        ("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
            //});

            //DisplayModes.Modes.Insert(0, new DefaultDisplayMode("iPad")
            //{
            //    ContextCondition = (context => context.Request.UserAgent.IndexOf
            //        ("iPad", StringComparison.OrdinalIgnoreCase) >= 0)
            //});


            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Bootstrapper(GlobalConfiguration.Configuration);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            BundleTable.Bundles.EnableDefaultBundles();
        }

        public  void Bootstrapper(HttpConfiguration configuration)
        {
            var unity = new UnityContainer();
            unity.RegisterType<HomeController>();
            
            configuration.DependencyResolver = new IoCContainer(unity);
        }
    }
}