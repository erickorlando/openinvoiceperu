using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OpenInvoicePeru.Comun.Constantes;
using OpenInvoicePeru.Comun.Dto.Intercambio;

namespace OpenInvoicePeru.Firmado
{
    public class Certificador : ICertificador
    {
        async Task<FirmadoResponse> ICertificador.FirmarXml(FirmadoRequest request)
        {
            var task = Task.Factory.StartNew(() =>
            {

                var response = new FirmadoResponse();

                var certificate = new X509Certificate2();
                certificate.Import(Convert.FromBase64String(request.CertificadoDigital),
                    request.PasswordCertificado, X509KeyStorageFlags.MachineKeySet);

                var xmlDoc = new XmlDocument();

                string resultado;

                var betterBytes = Encoding.Convert(Encoding.UTF8,
                    Encoding.GetEncoding(Formatos.EncodingIso),
                    Convert.FromBase64String(request.TramaXmlSinFirma));

                using (var documento = new MemoryStream(betterBytes))
                {
                    xmlDoc.PreserveWhitespace = true;
                    xmlDoc.Load(documento);

                    var indiceNodo = request.UnSoloNodoExtension ? 0 : 1;

                    var nodoExtension = xmlDoc.GetElementsByTagName("ExtensionContent", EspacioNombres.ext)
                        .Item(indiceNodo);
                    if (nodoExtension == null)
                        throw new InvalidOperationException("No se pudo encontrar el nodo ExtensionContent en el XML");
                    nodoExtension.RemoveAll();

                    // Creamos el objeto SignedXml.
                    var signedXml = new SignedXml(xmlDoc) {SigningKey = certificate.PrivateKey};
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
                        response.ResumenFirma = Convert.ToBase64String(reference.DigestValue);
                    response.ValorFirma = Convert.ToBase64String(signedXml.SignatureValue);

                    nodoExtension.AppendChild(signedXml.GetXml());

                    using (var memDoc = new MemoryStream())
                    {

                        using (var writer = XmlWriter.Create(memDoc,
                            new XmlWriterSettings {Encoding = Encoding.GetEncoding(Formatos.EncodingIso)}))
                        {
                            xmlDoc.WriteTo(writer);
                        }

                        resultado = Convert.ToBase64String(memDoc.ToArray());

                    }
                }
                response.TramaXmlFirmado = resultado;

                return response;
            });

            return await task;
        }
    }
}