#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoRelacionado
    {
#if !SILVERLIGHT
        [JsonProperty(Order = 1, Required = Required.Always)]
#endif
        public string NroDocumento { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 2, Required = Required.Always)]
#endif
        public string TipoDocumento { get; set; }
    }
}