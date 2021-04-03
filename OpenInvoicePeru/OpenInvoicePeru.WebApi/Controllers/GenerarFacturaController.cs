using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.WebApi.Utils;
using OpenInvoicePeru.Xml;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web.Http;

namespace OpenInvoicePeru.WebApi.Controllers
{
    /// <inheritdoc />
    public class GenerarFacturaController : ApiController
    {
        private readonly IDocumentoXml _documentoXml;
        private readonly ISerializador _serializador;
        private readonly TelegramService _telegramService;

        /// <inheritdoc />
        public GenerarFacturaController(ISerializador serializador)
        {
            _serializador = serializador;
            _documentoXml = new FacturaXml();
            //_documentoXml = _documentoXml = UnityConfig.Container
            //    .Resolve<IDocumentoXml>(GetType().Name);
            _telegramService = new TelegramService();
        }

        /// <summary>
        /// Generar el XML para una Factura o una Boleta.
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(DocumentoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IHttpActionResult> Post([FromBody] DocumentoElectronico documento)
        {
            var response = new DocumentoResponse();
            try
            {
                var invoice = _documentoXml.Generar(documento);
                response.TramaXmlSinFirma = await _serializador.GenerarXml(invoice);
                var serieCorrelativo = documento.IdDocumento.Split('-');
                response.ValoresParaQr =
                    $"{documento.Emisor.NroDocumento}|{documento.TipoDocumento}|{serieCorrelativo[0]}|{serieCorrelativo[1]}|{documento.TotalIgv:N2}|{documento.TotalVenta:N2}|{Convert.ToDateTime(documento.FechaEmision):yyyy-MM-dd}|{documento.Receptor.TipoDocumento}|{documento.Receptor.NroDocumento}|";

                string ipAddress;
                await Task.Factory.StartNew(async () =>
                {
                    if (!NetworkInterface.GetIsNetworkAvailable())
                        return;

                    var host = await Dns.GetHostEntryAsync(Environment.MachineName);
                    ipAddress = host.AddressList
                        .FirstOrDefault(p => p.AddressFamily == AddressFamily.InterNetwork)
                        ?.ToString();
                    
                    await _telegramService.EnviarMensaje($"{documento.Emisor.NroDocumento}: {documento.Emisor.NombreLegal} => {documento.Receptor.NombreLegal} | {documento.IdDocumento} desde {Environment.MachineName} en {ipAddress}");

                });

                response.Exito = true;
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
                response.Exito = false;
            }

            return Ok(response);
        }
    }
}
