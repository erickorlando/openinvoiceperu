#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public abstract class DocumentoResumenDetalle
    {
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public int Id { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string TipoDocumento { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string Serie { get; set; }
    }
}