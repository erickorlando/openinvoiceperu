using System;
using System.Threading.Tasks;
using System.Web.Http;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Xml;

namespace OpenInvoicePeru.WebApi.Controllers
{
    public class GenerarNotaCreditoController : ApiController
    {
        private readonly IDocumentoXml _documentoXml;
        private readonly ISerializador _serializador;

        public GenerarNotaCreditoController(IDocumentoXml documentoXml, ISerializador serializador)
        {
            _documentoXml = documentoXml;
            _serializador = serializador;
        }

        public async Task<DocumentoResponse> Post([FromBody] DocumentoElectronico documento)
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

            return response;
        }

    }
}
