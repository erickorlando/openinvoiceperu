using System;
using System.Web.Http;
using OpenInvoicePeru.Firmado.Models;
using OpenInvoicePeru.Firmado;

namespace OpenInvoicePeru.WebApi.Controllers
{
    public class GenerarRetencionController : ApiController
    {
        public DocumentoResponse Post([FromBody] DocumentoRetencion documento)
        {
            var response = new DocumentoResponse();
            try
            {
                var invoice = Generador.GenerarRetention(documento);

                var serializador = new Serializador();

                response.TramaXmlSinFirma = serializador.GenerarXml(invoice);
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