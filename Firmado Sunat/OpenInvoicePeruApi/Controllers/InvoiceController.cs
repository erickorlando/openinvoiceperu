using System.Web.Http;
using OpenInvoicePeru.FirmadoSunat;
using OpenInvoicePeru.FirmadoSunat.Models;

namespace OpenInvoicePeruApi.Controllers
{
    public class InvoiceController : ApiController
    {
        public string Post([FromBody] DocumentoElectronico documento)
        {
            var invoice = Generador.GenerarInvoice(documento);

            var serializador = new Serializador { TipoDocumento = 1 };

            return serializador.GenerarXmlFisico(invoice,
                $"{documento.Emisor.NroDocumento}-{documento.TipoDocumento}-{documento.IdDocumento}");

        }
    }
}
