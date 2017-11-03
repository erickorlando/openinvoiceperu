using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using OpenInvoicePeru.Comun.Constantes;
using OpenInvoicePeru.Servicio.Soap.Consultas;

namespace OpenInvoicePeru.Servicio.Soap
{
    public class ServicioSunatConsultas : IServicioSunatConsultas
    {
        private billServiceClient _proxyConsultas;

        Binding CreateBinding()
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            var elements = binding.CreateBindingElements();
            elements.Find<SecurityBindingElement>().IncludeTimestamp = false;
            return new CustomBinding(elements);
        }

        void IServicioSunat.Inicializar(ParametrosConexion parametros)
        {
            System.Net.ServicePointManager.UseNagleAlgorithm = true;
            System.Net.ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.CheckCertificateRevocationList = true;

            _proxyConsultas = new billServiceClient(CreateBinding(), new EndpointAddress(parametros.EndPointUrl))
            {
                ClientCredentials =
                {
                    UserName =
                    {
                        UserName = parametros.Ruc + parametros.UserName,
                        Password = parametros.Password
                    }
                }
            };
        }

        RespuestaSincrono IServicioSunatConsultas.ConsultarConstanciaDeRecepcion(DatosDocumento request)
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