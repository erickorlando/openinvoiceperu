using System;
using System.Threading.Tasks;
using System.Web.Http;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.WebApi.Utils;

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
        public async Task<FirmadoResponse> Post([FromBody]FirmadoRequest request)
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

            return response;
        }

    }
}
