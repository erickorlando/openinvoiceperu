using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ItemRetencion : DocumentoRelacionado
    {
        [JsonProperty(Required = Required.Always)]
        public string FechaEmision { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal ImporteTotal { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string MonedaDocumentoRelacionado { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string FechaPago { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int NumeroPago { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal ImporteSinRetencion { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal ImporteRetenido { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string FechaRetencion { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal ImporteTotalNeto { get; set; }

        public decimal TipoCambio { get; set; }

        public string FechaTipoCambio { get; set; }
    }
}