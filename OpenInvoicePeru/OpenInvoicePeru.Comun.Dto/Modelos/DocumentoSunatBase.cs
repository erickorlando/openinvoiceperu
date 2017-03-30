#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoSunatBase
    {
#if !SILVERLIGHT
        [JsonProperty(Order = 1, Required = Required.Always)]
#endif
        public string IdDocumento { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 2, Required = Required.Always)]
#endif
        public string FechaEmision { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 3, Required = Required.Always)]
#endif
        public Contribuyente Emisor { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 4, Required = Required.Always)]
#endif
        public Contribuyente Receptor { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 5, Required = Required.Always)]
#endif
        public string Moneda { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 6)]
#endif
        public string Observaciones { get; set; }
    }
}