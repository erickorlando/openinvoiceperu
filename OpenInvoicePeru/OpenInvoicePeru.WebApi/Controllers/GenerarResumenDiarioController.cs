using System;
using System.Threading.Tasks;
using System.Web.Http;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Xml;
using Microsoft.Practices.Unity;

namespace OpenInvoicePeru.WebApi.Controllers
{
    /// <inheritdoc />
    [RoutePrefix("api/GenerarResumenDiario")]
    public class GenerarResumenDiarioController : ApiController
    {
        private IDocumentoXml _documentoXml;
        private readonly ISerializador _serializador;

        /// <inheritdoc />
        public GenerarResumenDiarioController(ISerializador serializador)
        {
            _serializador = serializador;
            _documentoXml = UnityConfig.GetConfiguredContainer()
                .Resolve<IDocumentoXml>(GetType().Name);
        }


        /// <summary>
        /// Genera el XML para el Resumen Diario CustomizationID 1.0
        /// </summary>
        [Route("v1")]
        [HttpPost]
        public async Task<DocumentoResponse> Post([FromBody] ResumenDiario resumen)
        {
            var response = new DocumentoResponse();
            try
            {
                var summary = _documentoXml.Generar(resumen);
                response.TramaXmlSinFirma = await _serializador.GenerarXml(summary);
                response.Exito = true;
            }
            catch (Exception ex)
            {
                response.Exito = false;
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
            }

            return response;
        }

        /// <summary>
        /// Genera el XML para el Resumen Diario CustomizationID 1.1
        /// </summary>
        [Route("v2")]
        [HttpPost]
        public async Task<DocumentoResponse> ResumenNuevo([FromBody] ResumenDiarioNuevo resumen)
        {
            var response = new DocumentoResponse();
            try
            {
                // Solucion temporal --> Issue #58
                _documentoXml = UnityConfig.GetConfiguredContainer().Resolve<IDocumentoXml>();
                var summary = _documentoXml.Generar(resumen);
                response.TramaXmlSinFirma = await _serializador.GenerarXml(summary);
                response.Exito = true;
            }
            catch (Exception ex)
            {
                response.Exito = false;
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
            }

            return response;
        }
    }
}
