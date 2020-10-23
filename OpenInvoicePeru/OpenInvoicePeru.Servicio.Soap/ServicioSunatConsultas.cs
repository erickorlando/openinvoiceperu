using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using OpenInvoicePeru.Comun.Constantes;
using OpenInvoicePeru.Servicio.Soap.Consultas;
using OpenInvoicePeru.Servicio.Soap.ConsultasSunat;
using OpenInvoicePeru.Servicio.Soap.Documentos;

namespace OpenInvoicePeru.Servicio.Soap
{
    public class ServicioSunatConsultas : IServicioSunatConsultas
    {
        private BizlinksOSEClient _proxyConsultas;
        private ConsultasSunat.billServiceClient _proxySunatConsultas;

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

            if (!parametros.EndPointUrl.Contains("sunat"))
                _proxyConsultas = new BizlinksOSEClient(CreateBinding(), new EndpointAddress(parametros.EndPointUrl))
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
            else
                _proxySunatConsultas = new ConsultasSunat.billServiceClient(CreateBinding(), new EndpointAddress(parametros.EndPointUrl))
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
                if (_proxyConsultas != null)
                {
                    _proxyConsultas.Open();

                    var resultado = _proxyConsultas.getStatusCdr(new StatusCdr
                    {
                        rucComprobante = request.RucEmisor,
                        tipoComprobante = request.TipoComprobante,
                        numeroComprobante = request.Numero.ToString()
                            .PadLeft(8, '0')
                            .Substring(0, 8),
                        serieComprobante = request.Serie
                    });

                    _proxyConsultas.Close();

                    if (resultado != null)
                        response.ConstanciaDeRecepcion = Convert.ToBase64String(resultado);

                    response.Exito = resultado != null;
                }

                if (_proxySunatConsultas != null)
                {
                    _proxySunatConsultas.Open();

                    var resultado = _proxySunatConsultas.getStatusCdr(
                        request.RucEmisor,
                        request.TipoComprobante,
                        request.Serie,
                        Convert.ToInt32(request.Numero)
                    );

                    _proxySunatConsultas.Close();

                    if (resultado.content != null)
                        response.ConstanciaDeRecepcion = Convert.ToBase64String(resultado.content);

                    response.Exito = resultado.statusCode != "98";
                }

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