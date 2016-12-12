using System;
using System.Web.Http;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Xml;

namespace OpenInvoicePeru.WebApi.Controllers
{
    public class GenerarComunicacionBajaController : ApiController
    {
        private readonly IDocumentoXml _documentoXml;
        private readonly ISerializador _serializador;

        public GenerarComunicacionBajaController(IDocumentoXml documentoXml, ISerializador serializador)
        {
            _documentoXml = documentoXml;
            _serializador = serializador;
        }

        public DocumentoResponse Post([FromBody]ComunicacionBaja baja)
        {
            var response = new DocumentoResponse();

            try
            {
                var voidedDocument = _documentoXml.Generar(baja);
                response.TramaXmlSinFirma = _serializador.GenerarXml(voidedDocument);
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