using System;
using System.ServiceModel;
using OpenInvoicePeru.Servicio.Soap.Documentos;

namespace OpenInvoicePeru.Servicio.Soap
{
    public class ServicioSunat : IServicioSunat
    {
        private readonly ParametrosConexion _parametros;
        private billServiceClient _proxy;

        public ServicioSunat(ParametrosConexion parametros)
        {
            _parametros = parametros;
            System.Net.ServicePointManager.UseNagleAlgorithm = true;
            System.Net.ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.CheckCertificateRevocationList = true;

            _proxy = new billServiceClient("ServicioSunat", parametros.EndPointUrl);
            // Agregamos el behavior configurado para soportar WS-Security.
            var behavior = new PasswordDigestBehavior(string.Concat(parametros.Ruc, parametros.UserName), parametros.Password);
            _proxy.Endpoint.EndpointBehaviors.Add(behavior);
        }

        RespuestaSincrono IServicioSunat.EnviarDocumento(DocumentoSunat request)
        {
            var dataOrigen = Convert.FromBase64String(request.TramaXml);
            var response =  new RespuestaSincrono();

            try
            {
                _proxy.Open();
                var resultado = _proxy.sendBill(request.NombreArchivo, dataOrigen);

                _proxy.Close();

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
                _proxy.Open();
                var resultado = _proxy.sendSummary(request.NombreArchivo, dataOrigen);

                _proxy.Close();

                response.NumeroTicket = resultado;
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
                _proxy.Open();
                var resultado = _proxy.getStatus(numeroTicket);

                _proxy.Close();

                var estado = (resultado.statusCode != "98");

                response.ConstanciaDeRecepcion = estado
                    ? Convert.ToBase64String(resultado.content) : "Aun en proceso";
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
            throw new System.NotImplementedException();
        }
    }
}