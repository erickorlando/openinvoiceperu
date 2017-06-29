#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoBaja : DocumentoResumenDetalle
    {
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string Correlativo { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string MotivoBaja { get; set; }
    }
}