#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ItemPercepcion : ItemSunatBase
    {
#if !SILVERLIGHT
        [JsonProperty(Order = 8, Required = Required.Always)]
#endif
        public decimal ImporteSinPercepcion { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 10, Required = Required.Always)]
#endif
        public decimal ImportePercibido { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 11, Required = Required.Always)]
#endif
        public string FechaPercepcion { get; set; }
    }
}