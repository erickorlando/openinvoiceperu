using System.Web.Http;
using OpenInvoicePeru.WebApi.Filters;
using Unity.AspNet.WebApi;

namespace OpenInvoicePeru.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.Container);
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new ValidateModelAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
