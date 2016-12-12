using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Ionic.Zip;
using OpenInvoicePeru.Comun.Constantes;

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
        string ISerializador.GenerarXml<T>(T objectToSerialize)
        {
            var serializer = new XmlSerializer(typeof(T));
            string resultado;

            using (var memStr = new MemoryStream())
            {
                using (var stream = new StreamWriter(memStr))
                {
                    serializer.Serialize(stream, objectToSerialize);
                }
                var betterBytes = Encoding.Convert(Encoding.UTF8, 
                    Encoding.GetEncoding(Formatos.EncodingIso), 
                    memStr.ToArray());
                resultado = Convert.ToBase64String(betterBytes);
            }
            return resultado;
        }

        /// <summary>
        /// Genera el ZIP del XML basandose en la trama del XML.
        /// </summary>
        /// <param name="tramaXml">Cadena Base64 con el contenido del XML</param>
        /// <param name="nombreArchivo">Nombre del archivo ZIP</param>
        /// <returns>Devuelve Cadena Base64 del archizo ZIP</returns>
        string ISerializador.GenerarZip(string tramaXml, string nombreArchivo)
        {
            var memOrigen = new MemoryStream(Convert.FromBase64String(tramaXml));
            var memDestino = new MemoryStream();
            string resultado;

            using (var fileZip = new ZipFile($"{nombreArchivo}.zip"))
            {
                fileZip.AddEntry($"{nombreArchivo}.xml", memOrigen);
                fileZip.Save(memDestino);
                resultado = Convert.ToBase64String(memDestino.ToArray());
            }
            // Liberamos memoria RAM.
            memOrigen.Close();
            memDestino.Close();

            return resultado;
        }

    }
}
