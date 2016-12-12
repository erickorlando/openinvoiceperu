using System;
using System.IO;
using System.Web.Http;
using System.Xml;
using Ionic.Zip;
using OpenInvoicePeru.Comun.Constantes;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Servicio;

namespace OpenInvoicePeru.WebApi.Controllers
{
    public class EnviarDocumentoController : ApiController
    {
        private readonly ISerializador _serializador;
        private readonly IServicioSunatDocumentos _servicioSunatDocumentos;

        public EnviarDocumentoController(ISerializador serializador, IServicioSunatDocumentos servicioSunatDocumentos)
        {
            _serializador = serializador;
            _servicioSunatDocumentos = servicioSunatDocumentos;
        }

        public EnviarDocumentoResponse Post([FromBody]EnviarDocumentoRequest request)
        {
            var response = new EnviarDocumentoResponse();
            var nombreArchivo = $"{request.Ruc}-{request.TipoDocumento}-{request.IdDocumento}";
            var tramaZip = _serializador.GenerarZip(request.TramaXmlFirmado, nombreArchivo);

            _servicioSunatDocumentos.Inicializar(new ParametrosConexion
            {
                Ruc = request.Ruc,
                UserName = request.UsuarioSol,
                Password = request.ClaveSol,
                EndPointUrl = request.EndPointUrl
            });

            var resultado = _servicioSunatDocumentos.EnviarDocumento(new DocumentoSunat
            {
                TramaXml = tramaZip,
                NombreArchivo = $"{nombreArchivo}.zip"
            });

            if (resultado.Exito)
            {
                var returnByte = Convert.FromBase64String(resultado.ConstanciaDeRecepcion);
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
                                    response.TramaZipCdr = resultado.ConstanciaDeRecepcion;
                                    response.Exito = true;
                                    response.NombreArchivo = nombreArchivo;
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
                response.MensajeRespuesta = resultado.ConstanciaDeRecepcion;
            }

            return response;
        }
    }
}
