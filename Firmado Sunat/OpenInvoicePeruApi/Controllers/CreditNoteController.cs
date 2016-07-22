using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OpenInvoicePeru.FirmadoSunat;
using OpenInvoicePeru.FirmadoSunat.Models;

namespace OpenInvoicePeruApi.Controllers
{
    public class CreditNoteController : ApiController
    {

        public string Post([FromBody] DocumentoElectronico documento)
        {
            var invoice = Generador.GenerarCreditNote(documento);

            var serializador = new Serializador { TipoDocumento = 1 };

            return serializador.GenerarXmlFisico(invoice,
                $"{documento.Emisor.NroDocumento}-{documento.TipoDocumento}-{documento.IdDocumento}");
        }

    }
}
