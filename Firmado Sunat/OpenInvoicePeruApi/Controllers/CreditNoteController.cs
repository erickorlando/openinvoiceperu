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

        public DocumentoResponse Post([FromBody] DocumentoElectronico documento)
        {
            var response = new DocumentoResponse();
            try
            {
                var notaCredito = Generador.GenerarCreditNote(documento);

                var serializador = new Serializador { TipoDocumento = 1 };

                response.TramaXmlSinFirma = serializador.GenerarXml(notaCredito);
            }
            catch (Exception ex)
            {
                response.TramaXmlSinFirma = ex.Message;
            }

            return response;
        }

    }
}
