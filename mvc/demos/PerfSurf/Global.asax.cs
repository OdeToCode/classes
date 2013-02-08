using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SignalR.Hosting.AspNet.Routing;

namespace PerfSurf
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        private static void RegisterBundles()
        {
            var defaultCss = new Bundle("~/Content/DefaultCss", new NoTransform());
            defaultCss.AddFile("~/Content/jquery.mobile-1.0.min.css");
            defaultCss.AddFile("~/Content/Site.css");

            var defaultJs = new Bundle("~/DefaultJs", new NoTransform());
            defaultJs.AddFile("~/Scripts/modernizr-2.0.6-development-only.js");
            defaultJs.AddFile("~/Scripts/jquery-1.6.4.js");            
            defaultJs.AddFile("~/Scripts/jquery-ui-1.8.11.js");            
            defaultJs.AddFile("~/Scripts/jquery.validate.js");
            defaultJs.AddFile("~/Scripts/jquery.unobtrusive-ajax.js");
            defaultJs.AddFile("~/Scripts/knockout-2.0.0.js");
            defaultJs.AddFile("~/Scripts/jquery.sparkline.js");            
            defaultJs.AddFile("~/Scripts/jquery.mobile-1.0.js");            
            defaultJs.AddFile("~/Scripts/jquery.tmpl.js");                        

            var rgraph = new Bundle("~/RGraph", new NoTransform());
            rgraph.AddFile("~/Scripts/Rgraph/RGraph.common.core.js");
            rgraph.AddFile("~/Scripts/Rgraph/RGraph.common.context.js");            
            rgraph.AddFile("~/Scripts/Rgraph/RGraph.common.zoom.js");
            rgraph.AddFile("~/Scripts/Rgraph/RGraph.common.effects.js");
            rgraph.AddFile("~/Scripts/Rgraph/RGraph.line.js");
            
            BundleTable.Bundles.Add(defaultCss);
            BundleTable.Bundles.Add(defaultJs);                       
            BundleTable.Bundles.Add(rgraph);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RegisterBundles();
        }
    }
}