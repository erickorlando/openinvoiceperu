using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class EnviarDocumentoRequest : EnvioDocumentoComun
    {
        [JsonProperty(Required = Required.Always)]
        public string TramaXmlFirmado { get; set; }
    }
}