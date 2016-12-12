using System;
using System.ServiceModel;

namespace OpenInvoicePeru.Servicio.Soap
{
    public class ServicioSunat : IServicioSunat
    {
        private readonly Documentos.billServiceClient _proxyDocumentos;
        private readonly Consultas.billServiceClient _proxyConsultas;

        public ServicioSunat(ParametrosConexion parametros)
        {
            System.Net.ServicePointManager.UseNagleAlgorithm = true;
            System.Net.ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.CheckCertificateRevocationList = true;

            _proxyDocumentos = new Documentos.billServiceClient("ServicioSunat", parametros.EndPointUrl);
            _proxyConsultas = new Consultas.billServiceClient("ConsultasSunat", parametros.EndPointUrl);
            // Agregamos el behavior configurado para soportar WS-Security.
            var behavior = new PasswordDigestBehavior(
                string.Concat(parametros.Ruc, 
                parametros.UserName), 
                parametros.Password);

            _proxyDocumentos.Endpoint.EndpointBehaviors.Add(behavior);
            _proxyConsultas.Endpoint.EndpointBehaviors.Add(behavior);
        }

        RespuestaSincrono IServicioSunat.EnviarDocumento(DocumentoSunat request)
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
                response.ConstanciaDeRecepcion = string.Concat(ex.Code.Name, ex.Message);
            }
            catch (Exception ex)
            {
                var msg = string.Concat(ex.InnerException?.Message, ex.Message);
                var faultCode = "<faultcode>";
                if (msg.Contains(faultCode))
                {
                    var posicion = msg.IndexOf(faultCode, StringComparison.Ordinal);
                    var codigoError = msg.Substring(posicion + faultCode.Length, 4);
                    msg = $"El Código de Error es {codigoError}";
                }
                response.ConstanciaDeRecepcion = msg;
            }

            return response;
        }

        RespuestaAsincrono IServicioSunat.EnviarResumen(DocumentoSunat request)
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
                response.NumeroTicket = string.Concat(ex.Code.Name, ex.Message);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? string.Concat(ex.InnerException.Message, ex.Message) : ex.Message;
                var faultCode = "<faultcode>";
                if (msg.Contains(faultCode))
                {
                    var posicion = msg.IndexOf(faultCode, StringComparison.Ordinal);
                    var codigoError = msg.Substring(posicion + faultCode.Length, 4);
                    msg = $"El Código de Error es {codigoError}";
                }
                response.NumeroTicket = msg;
            }

            return response;
        }

        RespuestaSincrono IServicioSunat.ConsultarTicket(string numeroTicket)
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
                response.ConstanciaDeRecepcion = string.Concat(ex.Code.Name, ex.Message);
            }
            catch (Exception ex)
            {
                string msg;
                msg = ex.InnerException != null ? string.Concat(ex.InnerException.Message, ex.Message) : ex.Message;
                var faultCode = "<faultcode>";
                if (msg.Contains(faultCode))
                {
                    var posicion = msg.IndexOf(faultCode, StringComparison.Ordinal);
                    var codigoError = msg.Substring(posicion + faultCode.Length, 4);
                    msg = $"El Código de Error es {codigoError}";
                }
                response.ConstanciaDeRecepcion = msg;
            }

            return response;
        }

        RespuestaSincrono IServicioSunat.ConsultarConstanciaDeRecepcion(DatosDocumento request)
        {
            var response = new RespuestaSincrono();

            try
            {
                _proxyConsultas.Open();
                var resultado = _proxyConsultas.getStatusCdr(request.RucEmisor, 
                    request.TipoComprobante, 
                    request.Serie, 
                    request.Numero);

                _proxyConsultas.Close();

                var estado = (resultado.statusCode != "98");

                response.ConstanciaDeRecepcion = estado
                    ? Convert.ToBase64String(resultado.content) : "Aun en proceso";
                response.Exito = true;
            }
            catch (FaultException ex)
            {
                response.ConstanciaDeRecepcion = string.Concat(ex.Code.Name, ex.Message);
            }
            catch (Exception ex)
            {
                string msg;
                msg = ex.InnerException != null ? string.Concat(ex.InnerException.Message, ex.Message) : ex.Message;
                var faultCode = "<faultcode>";
                if (msg.Contains(faultCode))
                {
                    var posicion = msg.IndexOf(faultCode, StringComparison.Ordinal);
                    var codigoError = msg.Substring(posicion + faultCode.Length, 4);
                    msg = $"El Código de Error es {codigoError}";
                }
                response.ConstanciaDeRecepcion = msg;
            }

            return response;
        }
    }
}