using System;
using System.Web.Http;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Firmado.Models;

namespace OpenInvoicePeru.WebApi.Controllers
{
    public class GenerarResumenDiarioController : ApiController
    {
        public DocumentoResponse Post([FromBody] ResumenDiario resumen)
        {
            var response = new DocumentoResponse();
            try
            {
                var summary = Generador.GenerarSummaryDocuments(resumen);
                var serializador = new Serializador();
                response.TramaXmlSinFirma = serializador.GenerarXml(summary);
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
