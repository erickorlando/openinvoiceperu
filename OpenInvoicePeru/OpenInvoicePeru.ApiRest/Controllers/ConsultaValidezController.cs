using OpenInvoicePeru.Comun.Dto.Exceptions;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.RestService;
using OpenInvoicePeru.RestService.ApiSunatDto;
using Polly;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OpenInvoicePeru.ApiRest.Controllers
{
    public class ConsultaValidezController : ApiController
    {
        private readonly IValidezComprobanteHelper _helper;
        private readonly Logger _logger;

        public ConsultaValidezController()
        {
            _helper = new ValidezComprobanteHelper();
            _logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(@".\webapi-.log", LogEventLevel.Information,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {CorrelationId} {Level:u3}] {UserName} {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        [HttpPost]
        [Route("api/ConsultaValidez/GenerarToken")]
        [SwaggerResponse(200, "OK", typeof(TokenResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(RespuestaComun))]
        [SwaggerResponse(209, "Conflicts", typeof(RespuestaComun))]
        public IHttpActionResult GenerarToken(CrearTokenRequest request)
        {
            var response = new TokenResponse();

            var result = _helper.GenerarToken(request.ClientId,
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
        [Route("api/ConsultaValidez/ValidaComprobantes")]
        [SwaggerResponse(200, "OK", typeof(List<ValidaComprobanteResponse>))]
        //[SwaggerResponse(400, "Bad Request", typeof(RespuestaComun))]
        //[SwaggerResponse(209, "Conflicts", typeof(RespuestaComun))]
        public IHttpActionResult ValidaComprobante([FromBody] ValidacionBathRequest request)
        {
            var responseList = new List<ValidaComprobanteResponse>();

            var policy = Policy.Handle<InvalidOperationException>()
                .Retry(3);

            _logger.Information("Objeto request llega como: {@request}", request);

            policy.Execute(() =>
            {
                foreach (var comprobanteRequest in request.Comprobantes)
                {
                    try
                    {
                        var response = ValidarComprobante(request, comprobanteRequest);

                        responseList.Add(response);
                    }
                    catch (Exception)
                    {
                        // Do Nothing
                    }
                }
            });

            return Ok(responseList);

        }

        private ValidaComprobanteResponse ValidarComprobante(ValidacionBathRequest request, ComprobanteRequest comprobanteRequest)
        {
            var response = new ValidaComprobanteResponse();

            _logger.Information("request llega como {@request}", request);
            _logger.Information("Comprobante request llega como {@comprobanteRequest}", comprobanteRequest);

            _logger.Information("La instancia de helper es {@helper}", _helper);

            var result = _helper.Validar(comprobanteRequest.RucReceptor,
                request.Token, new ValidacionRequest
                {
                    RucEmisor = comprobanteRequest.RucEmisor,
                    CodigoComprobante = comprobanteRequest.TipoComprobante,
                    FechaEmision = comprobanteRequest.FechaEmision,
                    NumeroSerie = comprobanteRequest.NumeroSerie,
                    Numero = comprobanteRequest.Numero,
                    Monto = comprobanteRequest.Monto
                });

            response.Exito = result.Success;

            if (result.Data?.Observaciones != null)
            {
                var obs = result.Data.Observaciones
                    .SelectMany(xc => xc)
                    .Select(x => x);

                response.Observaciones = string.Join(" ", obs);
            }

            if (response.Exito)
            {
                response.CodigoEstadoComprobante = result.Data?.EstadoComprobante;
                response.CodigoEstadoRuc = result.Data?.EstadoRuc;
                response.CodigoEstadoDomicilio = result.Data?.CondicionDomicilio;

                response.EstadoComprobante = _estadosComprobante[response.CodigoEstadoComprobante ?? "0"];
                response.EstadoRuc = _estadosContribuyente[response.CodigoEstadoRuc ?? "22"];
                response.EstadoDomicilio = _estadosCondicionDomicilio[response.CodigoEstadoDomicilio ?? "20"];
                response.NroCpe = $"{comprobanteRequest.NumeroSerie}-{comprobanteRequest.Numero:00000000}";
            }
            else
            {
                response.MensajeError = result.Message;
                response.NroCpe = $"{comprobanteRequest.NumeroSerie}-{comprobanteRequest.Numero:00000000}";
                if (response.EstadoComprobante == "0")
                    throw new NoExisteCpeException(response.MensajeError);
            }


            return response;
        }
    }
}