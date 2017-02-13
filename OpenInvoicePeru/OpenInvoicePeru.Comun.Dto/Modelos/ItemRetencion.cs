using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ItemRetencion : ItemSunatBase
    {
        [JsonProperty(Order = 8, Required = Required.Always)]
        public decimal ImporteSinRetencion { get; set; }

        [JsonProperty(Order = 10, Required = Required.Always)]
        public decimal ImporteRetenido { get; set; }

        [JsonProperty(Order = 11, Required = Required.Always)]
        public string FechaRetencion { get; set; }
    }
}