using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class ConsultaConstanciaRequest : EnvioDocumentoComun
    {
        [JsonProperty(Required = Required.Always)]
        public string Serie { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int Numero { get; set; }
    }
}