using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Ionic.Zip;
using OpenInvoicePeru.Comun.Constantes;

namespace OpenInvoicePeru.Firmado
{
    public class Serializador
    {
        private readonly string _encodingIso = "ISO-8859-1";

        /// <summary>
        /// Cadena Base64 del certificado Digital
        /// </summary>
        public string RutaCertificadoDigital { get; set; }
        
        /// <summary>
        /// Si el certificado digital tiene Clave se coloca aquí
        /// </summary>
        public string PasswordCertificado { get; set; }
        
        /// <summary>
        /// Hash de la Firma del Documento
        /// </summary>
        public string DigestValue { get; set; }

        /// <summary>
        /// Indicar si hay un solo nodo UBLExtension
        /// </summary>
        public bool UnSoloNodoExtension { get; set; }
        
        /// <summary>
        /// Resumen de la Firma
        /// </summary>
        public string ValorFirma { get; set; }

        public Serializador()
        {
            UnSoloNodoExtension = false;
        }

        /// <summary>
        /// Genera el XML basado en una clase con el atributo Serializable
        /// </summary>
        /// <typeparam name="T">Clase a serializar</typeparam>
        /// <param name="objectToSerialize">Instancia de la Clase</param>
        /// <returns>Devuelve una cadena Base64 del archivo XML</returns>
        public string GenerarXml<T>(T objectToSerialize)
        {
            var serializer = new XmlSerializer(typeof(T));
            string resultado;

            using (var memStr = new MemoryStream())
            {
                using (var stream = new StreamWriter(memStr))
                {
                    serializer.Serialize(stream, objectToSerialize);
                }
                var betterBytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(_encodingIso), memStr.ToArray());
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
        public string GenerarZip(string tramaXml, string nombreArchivo)
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

        public string FirmarXml(string tramaXml)
        {

            // Vamos a firmar el XML con la ruta del certificado que está como serializado.

            var certificate = new X509Certificate2();
            certificate.Import(Convert.FromBase64String(RutaCertificadoDigital),
                PasswordCertificado, X509KeyStorageFlags.MachineKeySet);

            var xmlDoc = new XmlDocument();

            string resultado;

            var betterBytes = Encoding.Convert(Encoding.UTF8, 
                Encoding.GetEncoding(_encodingIso), 
                Convert.FromBase64String(tramaXml));

            using (var documento = new MemoryStream(betterBytes))
            {
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load(documento);

                var indiceNodo = UnSoloNodoExtension ? 0 : 1;

                var nodoExtension = xmlDoc.GetElementsByTagName("ExtensionContent", EspacioNombres.ext)
                    .Item(indiceNodo);
                if (nodoExtension == null)
                    throw new InvalidOperationException("No se pudo encontrar el nodo ExtensionContent en el XML");
                nodoExtension.RemoveAll();

                // Creamos el objeto SignedXml.
                var signedXml = new SignedXml(xmlDoc) { SigningKey = (RSA)certificate.PrivateKey };
                signedXml.SigningKey = certificate.PrivateKey;
                var xmlSignature = signedXml.Signature;

                var env = new XmlDsigEnvelopedSignatureTransform();

                var reference = new Reference(string.Empty);
                reference.AddTransform(env);
                xmlSignature.SignedInfo.AddReference(reference);

                var keyInfo = new KeyInfo();
                var x509Data = new KeyInfoX509Data(certificate);

                x509Data.AddSubjectName(certificate.Subject);

                keyInfo.AddClause(x509Data);
                xmlSignature.KeyInfo = keyInfo;
                xmlSignature.Id = "SignOpenInvoicePeru";
                signedXml.ComputeSignature();

                // Recuperamos el valor Hash de la firma para este documento.
                if (reference.DigestValue != null)
                    DigestValue = Convert.ToBase64String(reference.DigestValue);
                ValorFirma = Convert.ToBase64String(signedXml.SignatureValue);

                nodoExtension.AppendChild(signedXml.GetXml());

                using (var memDoc = new MemoryStream())
                {

                    using (var writer = XmlWriter.Create(memDoc, 
                        new XmlWriterSettings { Encoding = Encoding.GetEncoding(_encodingIso) }))
                    {
                        xmlDoc.WriteTo(writer);
                    }

                    resultado = Convert.ToBase64String(memDoc.ToArray());

                }
            }

            return resultado;
        }

    }
}
