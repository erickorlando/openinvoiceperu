using System;
using Microsoft.Practices.Unity;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Servicio;
using OpenInvoicePeru.Servicio.Soap;
using OpenInvoicePeru.WebApi.Controllers;
using OpenInvoicePeru.Xml;

namespace OpenInvoicePeru.WebApi
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

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
