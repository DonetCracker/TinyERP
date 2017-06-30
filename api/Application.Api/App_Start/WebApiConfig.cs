namespace App.Api
{
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Services.Replace(typeof(IHttpControllerTypeResolver), new App.Common.MVC.Resolver.HttpControllerTypeResolver());

            //var corsAttr = new EnableCorsAttribute("*", "*", "*");
            //var corsAttr = new EnableCorsAttribute("*", "Accept,Origin,content-type,authtoken,cache-control,x-requested-with", "*");
            //config.EnableCors(corsAttr);
            //config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { controller = "users", id = RouteParameter.Optional });
        }
    }
}
