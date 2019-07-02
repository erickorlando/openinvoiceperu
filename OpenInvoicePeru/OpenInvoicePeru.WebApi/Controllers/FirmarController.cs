using System;
using System.Threading.Tasks;
using System.Web.Http;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.WebApi.Utils;
using Swashbuckle.Swagger.Annotations;

namespace OpenInvoicePeru.WebApi.Controllers
{
    /// <inheritdoc />
    public class FirmarController : ApiController
    {
        private readonly ICertificador _certificador;

        /// <inheritdoc />
        public FirmarController(ICertificador certificador)
        {
            _certificador = certificador;
        }

        /// <summary>
        /// Firma el Documento XML con el Certificado Digital.
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(FirmadoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IHttpActionResult> Post([FromBody]FirmadoRequest request)
        {
            var response = new FirmadoResponse();

            try
            {
                response = await _certificador.FirmarXml(request);
                response.Exito = true;
                if (!string.IsNullOrEmpty(request.ValoresQr))
                    response.CodigoQr = QrHelper.GenerarImagenQr($"{request.ValoresQr}{response.ResumenFirma}");
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
