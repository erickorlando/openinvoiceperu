using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class FirmadoRequest
    {
        [JsonProperty(Required = Required.Always)]
        public string CertificadoDigital { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string PasswordCertificado { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TramaXmlSinFirma { get; set; }

    }
}