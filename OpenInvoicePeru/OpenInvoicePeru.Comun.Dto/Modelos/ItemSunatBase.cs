#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ItemSunatBase : DocumentoRelacionado
    {
#if !SILVERLIGHT
        [JsonProperty(Order = 3, Required = Required.Always)]
#endif
        public string FechaEmision { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 4, Required = Required.Always)]
#endif
        public decimal ImporteTotal { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 5, Required = Required.Always)]
#endif
        public string MonedaDocumentoRelacionado { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 6, Required = Required.Always)]
#endif
        public int NumeroPago { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 7, Required = Required.Always)]
#endif
        public decimal ImporteTotalNeto { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 9, Required = Required.Always)]
#endif
        public string FechaPago { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 12)]
#endif
        public decimal TipoCambio { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 13)]
#endif
        public string FechaTipoCambio { get; set; }
    }
}