using System.Web.Http;
using Microsoft.Practices.Unity.WebApi;
using OpenInvoicePeru.WebApi.Filters;

namespace OpenInvoicePeru.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());
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
