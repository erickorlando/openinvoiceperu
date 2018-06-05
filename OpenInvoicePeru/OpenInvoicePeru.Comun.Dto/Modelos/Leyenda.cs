using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Leyenda
    {
        [JsonProperty(Required = Required.Always)]
        public string Codigo { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Descripcion { get; set; }
    }
}