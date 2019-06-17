using System;
using System.Threading.Tasks;
using System.Web.Http;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Xml;
using Microsoft.Practices.Unity;

namespace OpenInvoicePeru.WebApi.Controllers
{
    public class GenerarFacturaController : ApiController
    {
        private readonly IDocumentoXml _documentoXml;
        private readonly ISerializador _serializador;

        public GenerarFacturaController(ISerializador serializador)
        {
            _serializador = serializador;
            _documentoXml = _documentoXml = UnityConfig.GetConfiguredContainer()
                .Resolve<IDocumentoXml>(GetType().Name);
        }

        public async Task<DocumentoResponse> Post([FromBody] DocumentoElectronico documento)
        {
            var response = new DocumentoResponse();
            try
            {
                var invoice = _documentoXml.Generar(documento);
                response.TramaXmlSinFirma = await _serializador.GenerarXml(invoice);
                var serieCorrelativo = documento.IdDocumento.Split('-');
                response.ValoresParaQr = $"{documento.Emisor.NroDocumento}|{documento.TipoDocumento}|{serieCorrelativo[0]}|{serieCorrelativo[1]}|{documento.TotalIgv:N2}|{documento.TotalVenta:N2}|{documento.FechaEmision:yyyy-MM-dd}|{documento.Receptor.TipoDocumento}|{documento.Receptor.NroDocumento}";
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
