using System.Collections.Generic;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.RestService;
using OpenInvoicePeru.RestService.ApiSunatDto;
using Swashbuckle.Swagger.Annotations;
using System.Linq;
using System.Web.Http;

namespace OpenInvoicePeru.WebApi.Controllers
{
    public class ConsultaValidezController : ApiController
    {
        [HttpPost]
        [Route("api/ConsultaValidez/GenerarToken")]
        [SwaggerResponse(200, "OK", typeof(TokenResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(RespuestaComun))]
        [SwaggerResponse(209, "Conflicts", typeof(RespuestaComun))]
        public IHttpActionResult GenerarToken(CrearTokenRequest request)
        {
            var response = new TokenResponse();

            var helper = new ValidezComprobanteHelper();

            var result = helper.GenerarToken(request.ClientId,
                request.ClientSecret);

            response.AccessToken = result.Result.AccessToken;
            response.Exito = result.Success;
            response.MensajeError = result.ErrorMessage;

            return Ok(response);

        }

        private readonly Dictionary<string, string> _estadosComprobante = new Dictionary<string, string>
        {
            {"0", "No existe"},
            {"1", "Aceptado"},
            {"2", "Anulado"},
            {"3", "Autorizado"},
            {"4", "No Autorizado"},
        };

        private readonly Dictionary<string, string> _estadosContribuyente = new Dictionary<string, string>
        {
            {"00", "Activo"},
            {"01", "Baja Provisional"},
            {"02", "Baja Prov. por Oficio"},
            {"03", "Suspension Temporal"},
            {"10", "Baja Definitiva"},
            {"11", "Baja de Oficio"},
            {"22", "Inhabilitado-Venta Unica"},
        };

        private readonly Dictionary<string, string> _estadosCondicionDomicilio = new Dictionary<string, string>
        {
            {"00", "Habido"},
            {"09", "Pendiente"},
            {"11", "Por Verificar"},
            {"12", "No Habido"},
            {"20", "No Hallado"},
        };

        [HttpPost]
        [Route("api/ConsultaValidez/ValidaComprobante")]
        [SwaggerResponse(200, "OK", typeof(ValidaComprobanteResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(RespuestaComun))]
        [SwaggerResponse(209, "Conflicts", typeof(RespuestaComun))]
        public IHttpActionResult ValidaComprobante(ValidaComprobanteRequest request)
        {
            var response = new ValidaComprobanteResponse();

            var helper = new ValidezComprobanteHelper();

            var result = helper.Validar(request.RucReceptor,
                request.Token, new ValidacionRequest
                {
                    RucEmisor = request.RucEmisor,
                    CodigoComprobante = request.TipoComprobante,
                    FechaEmision = request.FechaEmision,
                    NumeroSerie = request.NumeroSerie,
                    Numero = request.Numero,
                    Monto = request.Monto
                });

            response.Exito = result.Success;

            if (result.Data.Observaciones != null)
            {
                var obs = result.Data.Observaciones
                    .SelectMany(xc => xc)
                    .Select(x => x);

                response.Observaciones = string.Join(" ", obs);
            }

            if (response.Exito)
            {
                response.CodigoEstadoComprobante = result.Data.EstadoComprobante;
                response.CodigoEstadoRuc = result.Data.EstadoRuc;
                response.CodigoEstadoDomicilio = result.Data.CondicionDomicilio;

                response.EstadoComprobante = _estadosComprobante[response.CodigoEstadoComprobante ?? "0"];
                response.EstadoRuc = _estadosContribuyente[response.CodigoEstadoRuc ?? "22"];
                response.EstadoDomicilio = _estadosCondicionDomicilio[response.CodigoEstadoDomicilio ?? "20"];
            }
            else
            {
                response.MensajeError = result.Message;
            }

            return Ok(response);
        }
    }
}