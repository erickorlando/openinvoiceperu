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
    public class DebitNoteController : ApiController
    {

        public DocumentoResponse Post([FromBody] DocumentoElectronico documento)
        {
            var response = new DocumentoResponse();
            try
            {
                var notaDebito = Generador.GenerarDebitNote(documento);

                var serializador = new Serializador { TipoDocumento = 1 };

                response.TramaXmlSinFirma = serializador.GenerarXml(notaDebito);
            }
            catch (Exception ex)
            {
                response.TramaXmlSinFirma = ex.Message;
            }

            return response;
        }

    }
}
