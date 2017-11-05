using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ItemSunatBase : DocumentoRelacionado
    {
        [JsonProperty(Order = 3, Required = Required.Always)]
        public string FechaEmision { get; set; }

        [JsonProperty(Order = 4, Required = Required.Always)]
        public decimal ImporteTotal { get; set; }

        [JsonProperty(Order = 5, Required = Required.Always)]
        public string MonedaDocumentoRelacionado { get; set; }

        [JsonProperty(Order = 6, Required = Required.Always)]
        public int NumeroPago { get; set; }

        [JsonProperty(Order = 7, Required = Required.Always)]
        public decimal ImporteTotalNeto { get; set; }

        [JsonProperty(Order = 9, Required = Required.Always)]
        public string FechaPago { get; set; }

        [JsonProperty(Order = 12)]
        public decimal TipoCambio { get; set; }

        [JsonProperty(Order = 13)]
        public string FechaTipoCambio { get; set; }
    }
}