using System;
using System.IO;
using System.Web.Http;
using System.Xml;
using Ionic.Zip;
using OpenInvoicePeru.FirmadoSunat;
using OpenInvoicePeru.FirmadoSunat.Estructuras;
using OpenInvoicePeru.FirmadoSunat.Models;

namespace OpenInvoicePeruApi.Controllers
{
    public class ConsultarTicketController : ApiController
    {
        public EnviarDocumentoResponse Post([FromBody] ConsultaTicketRequest request)
        {
            var response = new EnviarDocumentoResponse();

            try
            {
                var conexionSunat = new ConexionSunat(new ConexionSunat.Parametros
                {
                    Ruc = request.Ruc,
                    UserName = request.UsuarioSol,
                    Password = request.ClaveSol,
                    EndPointUrl = request.EndPointUrl
                });

                var resultado = conexionSunat.ObtenerEstado(request.NroTicket);

                if (resultado.Item2)
                {
                    var returnByte = Convert.FromBase64String(resultado.Item1);
                    using (var memRespuesta = new MemoryStream(returnByte))
                    {
                        using (var zipFile = ZipFile.Read(memRespuesta))
                        {
                            foreach (var entry in zipFile.Entries)
                            {
                                if (!entry.FileName.EndsWith(".xml")) continue;
                                using (var ms = new MemoryStream())
                                {
                                    entry.Extract(ms);
                                    ms.Position = 0;
                                    var responseReader = new StreamReader(ms);
                                    var responseString = responseReader.ReadToEnd();
                                    try
                                    {
                                        var xmlDoc = new XmlDocument();
                                        xmlDoc.LoadXml(responseString);

                                        var xmlnsManager = new XmlNamespaceManager(xmlDoc.NameTable);

                                        xmlnsManager.AddNamespace("ar", EspacioNombres.ar);
                                        xmlnsManager.AddNamespace("cac", EspacioNombres.cac);
                                        xmlnsManager.AddNamespace("cbc", EspacioNombres.cbc);

                                        response.CodigoRespuesta = xmlDoc.SelectSingleNode(EspacioNombres.nodoResponseCode,
                                            xmlnsManager)?.InnerText;

                                        response.MensajeRespuesta = xmlDoc.SelectSingleNode(EspacioNombres.nodoDescription,
                                            xmlnsManager)?.InnerText;
                                        response.Exito = true;

                                    }
                                    catch (Exception ex)
                                    {
                                        response.MensajeError = ex.Message;
                                        response.Pila = ex.StackTrace;
                                        response.Exito = false;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    response.Exito = true;
                    response.MensajeRespuesta = resultado.Item1;
                }
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
