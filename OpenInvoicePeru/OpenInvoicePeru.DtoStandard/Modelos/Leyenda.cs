using Newtonsoft.Json;

namespace OpenInvoicePeru.DtoStandard.Modelos
{
    public class Leyenda
    {
        [JsonProperty(Required = Required.Always)]
        public string Codigo { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Descripcion { get; set; }
    }
}