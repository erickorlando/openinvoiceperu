using System;
using System.Threading.Tasks;
using System.Web.Http;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Servicio;

namespace OpenInvoicePeru.WebApi.Controllers
{
    public class ConsultarConstanciaController : ApiController
    {
        private readonly IServicioSunatConsultas _servicioSunatConsultas;
        private readonly ISerializador _serializador;

        public ConsultarConstanciaController(IServicioSunatConsultas servicioSunatConsultas, ISerializador serializador)
        {
            _servicioSunatConsultas = servicioSunatConsultas;
            _serializador = serializador;
        }

        public async Task<EnviarDocumentoResponse> Post([FromBody] ConsultaConstanciaRequest request)
        {
            var response = new EnviarDocumentoResponse();

            try
            {
                _servicioSunatConsultas.Inicializar(new ParametrosConexion
                {
                    Ruc = request.Ruc,
                    UserName = request.UsuarioSol,
                    Password = request.ClaveSol,
                    EndPointUrl = request.EndPointUrl
                });

                var resultado = _servicioSunatConsultas.ConsultarConstanciaDeRecepcion(new DatosDocumento
                {
                    RucEmisor = request.Ruc,
                    TipoComprobante = request.TipoDocumento,
                    Serie = request.Serie,
                    Numero = request.Numero
                });

                if (!resultado.Exito)
                {
                    response.Exito = false;
                    response.MensajeRespuesta = resultado.MensajeError;
                }
                else
                    response = await _serializador.GenerarDocumentoRespuesta(resultado.ConstanciaDeRecepcion);
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
