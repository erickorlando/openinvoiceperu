using System;
using System.Threading.Tasks;
using System.Web.Http;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Servicio;
using OpenInvoicePeru.Servicio.Soap;
using Swashbuckle.Swagger.Annotations;

namespace OpenInvoicePeru.ApiRest.Controllers
{
    /// <inheritdoc />
    public class ConsultarTicketController : ApiController
    {
        private readonly IServicioSunatDocumentos _servicioSunatDocumentos;
        private readonly ISerializador _serializador;

        /// <inheritdoc />
        public ConsultarTicketController()
        {
            _servicioSunatDocumentos = new ServicioSunatDocumentos();
            _serializador = new Serializador();
        }

        /// <summary>
        /// Consulta el Ticket existen en SUNAT (Solo Produccion)
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(EnviarDocumentoResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IHttpActionResult> Post([FromBody] ConsultaTicketRequest request)
        {
            var response = new EnviarDocumentoResponse();

            try
            {
                _servicioSunatDocumentos.Inicializar(new ParametrosConexion
                {
                    Ruc = request.Ruc,
                    UserName = request.UsuarioSol,
                    Password = request.ClaveSol,
                    EndPointUrl = request.EndPointUrl
                });

                var resultado = _servicioSunatDocumentos.ConsultarTicket(request.NroTicket);

                if (!resultado.Exito)
                {
                    response.Exito = false;
                    response.MensajeError = resultado.MensajeError;
                }
                else
                    response = await _serializador.GenerarDocumentoRespuesta(resultado.ConstanciaDeRecepcion);
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Source == "DotNetZip" ? "El Ticket no existe" : ex.Message;
                response.Pila = ex.StackTrace;
                response.Exito = false;
            }

            return Ok(response);
        }
    }
}
