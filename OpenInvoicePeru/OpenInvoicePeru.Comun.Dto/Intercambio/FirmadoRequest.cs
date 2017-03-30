#if !SILVERLIGHT
using Newtonsoft.Json;
#endif
namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class FirmadoRequest
    {
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string CertificadoDigital { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string PasswordCertificado { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string TramaXmlSinFirma { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public bool UnSoloNodoExtension { get; set; }
    }
}