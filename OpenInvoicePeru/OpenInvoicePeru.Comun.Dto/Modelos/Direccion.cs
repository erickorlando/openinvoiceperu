using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Direccion
    {
        [JsonProperty(Required = Required.Always)]
        public string Ubigeo { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string DireccionCompleta { get; set; }
    }
}