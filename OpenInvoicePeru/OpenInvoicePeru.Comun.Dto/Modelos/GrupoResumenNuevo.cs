#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class GrupoResumenNuevo : GrupoResumen
    {
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif

        public string IdDocumento { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string TipoDocumentoReceptor { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string NroDocumentoReceptor { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public int CodigoEstadoItem { get; set; }

        public string DocumentoRelacionado { get; set; }

        public string TipoDocumentoRelacionado { get; set; }
    }
}