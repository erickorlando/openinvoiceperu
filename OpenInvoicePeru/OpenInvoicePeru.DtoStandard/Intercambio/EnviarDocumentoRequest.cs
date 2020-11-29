using Newtonsoft.Json;

namespace OpenInvoicePeru.DtoStandard.Intercambio
{
    public class EnviarDocumentoRequest : EnvioDocumentoComun
    {
        [JsonProperty(Required = Required.Always)]
        public string TramaXmlFirmado { get; set; }

    }
}