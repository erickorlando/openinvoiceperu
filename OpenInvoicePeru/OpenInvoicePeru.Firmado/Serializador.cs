using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using OpenInvoicePeru.Comun.Constantes;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using System.IO.Compression;
using System.Text;

namespace OpenInvoicePeru.Firmado
{
    public class Serializador : ISerializador
    {

        /// <summary>
        /// Genera el XML basado en una clase con el atributo Serializable
        /// </summary>
        /// <typeparam name="T">Clase a serializar</typeparam>
        /// <param name="objectToSerialize">Instancia de la Clase</param>
        /// <returns>Devuelve una cadena Base64 del archivo XML</returns>
        async Task<string> ISerializador.GenerarXml<T>(T objectToSerialize)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var serializer = new XmlSerializer(objectToSerialize.GetType());
                string resultado;

                using (var memStr = new MemoryStream())
                {
                    using (var stream = new StreamWriter(memStr))
                    {
                        serializer.Serialize(stream, objectToSerialize);
                    }
                    resultado = Convert.ToBase64String(memStr.ToArray());
                }
                return resultado;
            });
            return await task;
        }

        /// <summary>
        /// Genera el ZIP del XML basandose en la trama del XML.
        /// </summary>
        /// <param name="tramaXml">Cadena Base64 con el contenido del XML</param>
        /// <param name="nombreArchivo">Nombre del archivo ZIP</param>
        /// <returns>Devuelve Cadena Base64 del archizo ZIP</returns>
        async Task<string> ISerializador.GenerarZip(string tramaXml, string nombreArchivo)
        {
            var task = Task.Factory.StartNew(() =>
            {
                string resultado;

                using (var memDestino = new MemoryStream())
                {
                    using (var ziparchive = new ZipArchive(memDestino, ZipArchiveMode.Create))
                    {

                        var zipItem = ziparchive.CreateEntry($"{nombreArchivo}.xml");

                        using (var zipFile = zipItem.Open())
                        {
                            var data = Convert.FromBase64String(tramaXml);
                            zipFile.Write(data, 0, data.Length);
                        }
                    }

                    resultado = Convert.ToBase64String(memDestino.ToArray());
                }

                return resultado;
            });

            return await task;
        }

        /// <summary>
        /// Lee la Constancia de Recepción SUNAT y devuelve el contenido
        /// </summary>
        /// <param name="constanciaRecepcion">Trama ZIP del CDR</param>
        /// <returns>Devuelve una clase <see cref="EnviarDocumentoResponse"/></returns>
        public async Task<EnviarDocumentoResponse> GenerarDocumentoRespuesta(string constanciaRecepcion)
        {
            var response = new EnviarDocumentoResponse();
            var returnByte = Convert.FromBase64String(constanciaRecepcion);
            using (var memRespuesta = new MemoryStream(returnByte))
            {
                if (memRespuesta.Length <= 0)
                {
                    response.MensajeError = "Respuesta SUNAT Vacío";
                    response.Exito = false;
                }
                else
                {
                    using (var zipFile = new ZipArchive(memRespuesta, ZipArchiveMode.Read))
                    {
                        foreach (var entry in zipFile.Entries)
                        {
                            if (!entry.Name.ToUpper().EndsWith(".XML")) continue;
                            using (var ms = entry.Open())
                            {
                                var responseReader = new StreamReader(ms);
                                var responseString = await responseReader.ReadToEndAsync();
                                try
                                {
                                    var xmlDoc = new XmlDocument();
                                    xmlDoc.LoadXml(responseString);

                                    var xmlnsManager = new XmlNamespaceManager(xmlDoc.NameTable);

                                    xmlnsManager.AddNamespace("ar", EspacioNombres.ar);
                                    xmlnsManager.AddNamespace("cac", EspacioNombres.cac);
                                    xmlnsManager.AddNamespace("cbc", EspacioNombres.cbc);

                                    var respuestaXml = new StringBuilder();

                                    var warningNodes = xmlDoc.SelectNodes("/ar:ApplicationResponse/cbc:Note", xmlnsManager);

                                    if (warningNodes?.Count > 0)
                                    {
                                        respuestaXml.AppendLine("Observaciones: ");
                                        foreach (XmlNode warningNode in warningNodes)
                                        {
                                            respuestaXml.AppendLine(warningNode.InnerText);
                                        }
                                    }

                                    respuestaXml.AppendLine(xmlDoc.SelectSingleNode(EspacioNombres.nodoDescription,
                                        xmlnsManager)?.InnerText);

                                    response.CodigoRespuesta =
                                        xmlDoc.SelectSingleNode(EspacioNombres.nodoResponseCode,
                                            xmlnsManager)?.InnerText;

                                    response.MensajeRespuesta = respuestaXml.ToString();
                                    respuestaXml.Length = 0;

                                    response.NroTicketCdr =
                                        xmlDoc.SelectSingleNode(EspacioNombres.nodoId,
                                            xmlnsManager)?.InnerText;

                                    response.TramaZipCdr = constanciaRecepcion;
                                    response.NombreArchivo = entry.Name;
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
            return response;
        }
    }
}
