using Newtonsoft.Json;

namespace OpenInvoicePeru.DtoStandard.Intercambio
{
    public class ConsultaConstanciaRequest : EnvioDocumentoComun
    {
        [JsonProperty(Required = Required.Always)]
        public string Serie { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int Numero { get; set; }
    }
}