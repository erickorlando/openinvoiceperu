using System;
using System.Web.Http;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Firmado.Models;

namespace OpenInvoicePeru.WebApi.Controllers
{
    public class GenerarNotaCreditoController : ApiController
    {

        public DocumentoResponse Post([FromBody] DocumentoElectronico documento)
        {
            var response = new DocumentoResponse();
            try
            {
                var notaCredito = Generador.GenerarCreditNote(documento);

                var serializador = new Serializador();

                response.TramaXmlSinFirma = serializador.GenerarXml(notaCredito);
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
