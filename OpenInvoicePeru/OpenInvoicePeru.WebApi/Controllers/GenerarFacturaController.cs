using System;
using System.Web.Http;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Xml;

namespace OpenInvoicePeru.WebApi.Controllers
{
    public class GenerarFacturaController : ApiController
    {
        private readonly IDocumentoXml _documentoXml;
        private readonly ISerializador _serializador;

        public GenerarFacturaController(IDocumentoXml documentoXml, ISerializador serializador)
        {
            _documentoXml = documentoXml;
            _serializador = serializador;
        }

        public DocumentoResponse Post([FromBody] DocumentoElectronico documento)
        {
            var response = new DocumentoResponse();
            try
            {
                var invoice = _documentoXml.Generar(documento);
                response.TramaXmlSinFirma = _serializador.GenerarXml(invoice);
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
