using System;
using System.ServiceModel;
using OpenInvoicePeru.Comun.Constantes;

namespace OpenInvoicePeru.Servicio.Soap
{
    public class ServicioSunatDocumentos : IServicioSunatDocumentos
    {
        private Documentos.billServiceClient _proxyDocumentos;

        void IServicioSunat.Inicializar(ParametrosConexion parametros)
        {
            System.Net.ServicePointManager.UseNagleAlgorithm = true;
            System.Net.ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.CheckCertificateRevocationList = true;

            _proxyDocumentos = new Documentos.billServiceClient("ServicioSunat", parametros.EndPointUrl);
            // Agregamos el behavior configurado para soportar WS-Security.
            var behavior = new PasswordDigestBehavior(
                string.Concat(parametros.Ruc,
                parametros.UserName),
                parametros.Password);

            _proxyDocumentos.Endpoint.EndpointBehaviors.Add(behavior);
        }

        RespuestaSincrono IServicioSunatDocumentos.EnviarDocumento(DocumentoSunat request)
        {
            var dataOrigen = Convert.FromBase64String(request.TramaXml);
            var response =  new RespuestaSincrono();

            try
            {
                _proxyDocumentos.Open();
                var resultado = _proxyDocumentos.sendBill(request.NombreArchivo, dataOrigen);

                _proxyDocumentos.Close();

                response.ConstanciaDeRecepcion = Convert.ToBase64String(resultado);
                response.Exito = true;
            }
            catch (FaultException ex)
            {
                response.MensajeError = string.Concat(ex.Code.Name, ex.Message);
            }
            catch (Exception ex)
            {
                var msg = string.Concat(ex.InnerException?.Message, ex.Message);
                if (msg.Contains(Formatos.FaultCode))
                {
                    var posicion = msg.IndexOf(Formatos.FaultCode, StringComparison.Ordinal);
                    var codigoError = msg.Substring(posicion + Formatos.FaultCode.Length, 4);
                    msg = $"El Código de Error es {codigoError}";
                }
                response.MensajeError = msg;
            }

            return response;
        }

        RespuestaAsincrono IServicioSunatDocumentos.EnviarResumen(DocumentoSunat request)
        {
            var dataOrigen = Convert.FromBase64String(request.TramaXml);
            var response = new RespuestaAsincrono();

            try
            {
                _proxyDocumentos.Open();
                var resultado = _proxyDocumentos.sendSummary(request.NombreArchivo, dataOrigen);

                _proxyDocumentos.Close();

                response.NumeroTicket = resultado;
                response.Exito = true;
            }
            catch (FaultException ex)
            {
                response.MensajeError = string.Concat(ex.Code.Name, ex.Message);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? string.Concat(ex.InnerException.Message, ex.Message) : ex.Message;
                if (msg.Contains(Formatos.FaultCode))
                {
                    var posicion = msg.IndexOf(Formatos.FaultCode, StringComparison.Ordinal);
                    var codigoError = msg.Substring(posicion + Formatos.FaultCode.Length, 4);
                    msg = $"El Código de Error es {codigoError}";
                }
                response.MensajeError = msg;
            }

            return response;
        }

        RespuestaSincrono IServicioSunatDocumentos.ConsultarTicket(string numeroTicket)
        {
            var response = new RespuestaSincrono();

            try
            {
                _proxyDocumentos.Open();
                var resultado = _proxyDocumentos.getStatus(numeroTicket);

                _proxyDocumentos.Close();

                var estado = (resultado.statusCode != "98");

                response.ConstanciaDeRecepcion = estado
                    ? Convert.ToBase64String(resultado.content) : "Aun en proceso";
                response.Exito = true;
            }
            catch (FaultException ex)
            {
                response.MensajeError = string.Concat(ex.Code.Name, ex.Message);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? string.Concat(ex.InnerException.Message, ex.Message) : ex.Message;
                if (msg.Contains(Formatos.FaultCode))
                {
                    var posicion = msg.IndexOf(Formatos.FaultCode, StringComparison.Ordinal);
                    var codigoError = msg.Substring(posicion + Formatos.FaultCode.Length, 4);
                    msg = $"El Código de Error es {codigoError}";
                }
                response.MensajeError = msg;
            }

            return response;
        }

        
    }
}