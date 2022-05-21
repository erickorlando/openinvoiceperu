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
    public class EnviarResumenController : ApiController
    {
        private readonly ISerializador _serializador;
        private readonly IServicioSunatDocumentos _servicioSunatDocumentos;

        /// <inheritdoc />
        public EnviarResumenController()
        {
            _serializador = new Serializador();
            _servicioSunatDocumentos = new ServicioSunatDocumentos();
        }

        /// <summary>
        /// Envia el Resumen Diario/Comunicacion de Baja a SUNAT
        /// </summary>
        [HttpPost]
        [SwaggerResponse(200, "OK", typeof(EnviarResumenResponse))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(209, "Conflicts", typeof(string))]
        public async Task<IHttpActionResult> Post([FromBody]EnviarDocumentoRequest request)
        {
            var response = new EnviarResumenResponse();
            var nombreArchivo = $"{request.Ruc}-{request.IdDocumento}";

            try
            {
                var tramaZip = await _serializador.GenerarZip(request.TramaXmlFirmado, nombreArchivo);

                _servicioSunatDocumentos.Inicializar(new ParametrosConexion
                {
                    Ruc = request.Ruc,
                    UserName = request.UsuarioSol,
                    Password = request.ClaveSol,
                    EndPointUrl = request.EndPointUrl
                });

                var resultado = _servicioSunatDocumentos.EnviarResumen(new DocumentoSunat
                {
                    NombreArchivo = $"{nombreArchivo}.zip",
                    TramaXml = tramaZip
                });
                
                if (resultado.Exito)
                {
                    response.NroTicket = resultado.NumeroTicket;
                    response.Exito = true;
                    response.NombreArchivo = nombreArchivo;
                }
                else
                {
                    response.MensajeError = resultado.MensajeError;
                    response.Exito = false;
                }
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
