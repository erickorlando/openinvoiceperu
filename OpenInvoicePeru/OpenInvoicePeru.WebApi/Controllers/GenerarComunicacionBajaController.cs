using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Xml;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace OpenInvoicePeru.WebApi.Controllers
{
    /// <inheritdoc />
    public class GenerarComunicacionBajaController : ApiController
    {
        private readonly IDocumentoXml _documentoXml;
        private readonly ISerializador _serializador;

        /// <inheritdoc />
        public GenerarComunicacionBajaController(ISerializador serializador)
        {
            _serializador = serializador;
            _documentoXml = new ComunicacionBajaXml();
        }

        /// <summary>
        /// Genera la Comunicacion de Baja.
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(DocumentoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IHttpActionResult> Post([FromBody]ComunicacionBaja baja)
        {
            var response = new DocumentoResponse();

            try
            {
                var voidedDocument = _documentoXml.Generar(baja);
                response.TramaXmlSinFirma = await _serializador.GenerarXml(voidedDocument);
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