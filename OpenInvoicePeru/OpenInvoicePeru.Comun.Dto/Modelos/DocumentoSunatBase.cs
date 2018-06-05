using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoSunatBase
    {
        [JsonProperty(Order = 1, Required = Required.Always)]
        public string IdDocumento { get; set; }

        [JsonProperty(Order = 2, Required = Required.Always)]
        public string FechaEmision { get; set; }

        [JsonProperty(Order = 3, Required = Required.Always)]
        public Negocio Emisor { get; set; }

        [JsonProperty(Order = 4, Required = Required.Always)]
        public Negocio Receptor { get; set; }

        [JsonProperty(Order = 5, Required = Required.Always)]
        public string Moneda { get; set; }

        [JsonProperty(Order = 6)]
        public string Observaciones { get; set; }
    }
}