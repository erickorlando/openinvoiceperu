using System;
using System.Web.Http;
using OpenInvoicePeru.FirmadoSunat;
using OpenInvoicePeru.FirmadoSunat.Models;

namespace OpenInvoicePeruApi.Controllers
{
    public class InvoiceController : ApiController
    {
        public DocumentoResponse Post([FromBody] DocumentoElectronico documento)
        {
            var response = new DocumentoResponse();
            try
            {
                var invoice = Generador.GenerarInvoice(documento);

                var serializador = new Serializador { TipoDocumento = 1 };

                //return serializador.GenerarXmlFisico(invoice,
                //    $"{documento.Emisor.NroDocumento}-{documento.TipoDocumento}-{documento.IdDocumento}");

                response.TramaXmlSinFirma = serializador.GenerarXml(invoice);
            }
            catch (Exception ex)
            {
                response.TramaXmlSinFirma = ex.Message;
            }

            return response;
        }
    }
}
