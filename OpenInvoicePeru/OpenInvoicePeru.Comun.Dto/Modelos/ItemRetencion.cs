#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ItemRetencion : ItemSunatBase
    {
#if !SILVERLIGHT
        [JsonProperty(Order = 8, Required = Required.Always)]
#endif
        public decimal ImporteSinRetencion { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 10, Required = Required.Always)]
#endif
        public decimal ImporteRetenido { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 11, Required = Required.Always)]
#endif
        public string FechaRetencion { get; set; }
    }
}