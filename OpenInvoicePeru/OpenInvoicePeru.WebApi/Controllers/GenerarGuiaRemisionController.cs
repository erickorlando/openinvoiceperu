using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Xml;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using Unity;

namespace OpenInvoicePeru.WebApi.Controllers
{
    /// <inheritdoc />
    public class GenerarGuiaRemisionController : ApiController
    {

        private readonly IDocumentoXml _documentoXml;
        private readonly ISerializador _serializador;

        /// <inheritdoc />
        public GenerarGuiaRemisionController(ISerializador serializador)
        {
            _serializador = serializador;
            _documentoXml = (IDocumentoXml)UnityConfig.Container.Resolve(GetType());
        }

        /// <summary>
        /// Genera el XML para la Guia de Remision.
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(DocumentoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IHttpActionResult> Post([FromBody] GuiaRemision documento)
        {
            var response = new DocumentoResponse();
            try
            {
                var notaCredito = _documentoXml.Generar(documento);
                response.TramaXmlSinFirma = await _serializador.GenerarXml(notaCredito);
                response.Exito = true;
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
                response.Exito = false;
            }

            return Ok(response);
        }
    }
}