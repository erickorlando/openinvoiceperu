using System;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Servicio;
using OpenInvoicePeru.Servicio.Soap;
using OpenInvoicePeru.WebApi.Controllers;
using OpenInvoicePeru.Xml;
using Unity;

namespace OpenInvoicePeru.WebApi
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container
                .RegisterType<ISerializador, Serializador>()
                .RegisterType<ICertificador, Certificador>()
                .RegisterType<IServicioSunatDocumentos, ServicioSunatDocumentos>()
                .RegisterType<IServicioSunatConsultas, ServicioSunatConsultas>();

            container
                .RegisterType<IDocumentoXml, FacturaXml>(nameof(GenerarFacturaController))
                .RegisterType<IDocumentoXml, NotaCreditoXml>(nameof(GenerarNotaCreditoController))
                .RegisterType<IDocumentoXml, NotaDebitoXml>(nameof(GenerarNotaDebitoController))
                .RegisterType<IDocumentoXml, ResumenDiarioXml>(nameof(GenerarResumenDiarioController))
                .RegisterType<IDocumentoXml, ResumenDiarioNuevoXml>()
                .RegisterType<IDocumentoXml, ComunicacionBajaXml>(nameof(GenerarComunicacionBajaController))
                .RegisterType<IDocumentoXml, RetencionXml>(nameof(GenerarRetencionController))
                .RegisterType<IDocumentoXml, PercepcionXml>(nameof(GenerarPercepcionController))
                .RegisterType<IDocumentoXml, GuiaRemisionXml>(nameof(GenerarGuiaRemisionController));
        }
    }
}