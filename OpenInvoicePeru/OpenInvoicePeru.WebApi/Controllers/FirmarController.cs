using System;
using System.Threading.Tasks;
using System.Web.Http;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Firmado;

namespace OpenInvoicePeru.WebApi.Controllers
{
    public class FirmarController : ApiController
    {
        private readonly ICertificador _certificador;

        public FirmarController(ICertificador certificador)
        {
            _certificador = certificador;
        }

        public async Task<FirmadoResponse> Post([FromBody]FirmadoRequest request)
        {
            var response = new FirmadoResponse();

            try
            {
                response = await _certificador.FirmarXml(request);
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
