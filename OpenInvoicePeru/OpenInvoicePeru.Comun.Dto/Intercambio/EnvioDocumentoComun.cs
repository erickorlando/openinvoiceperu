#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public abstract class EnvioDocumentoComun
    {
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string Ruc { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string UsuarioSol { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string ClaveSol { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string IdDocumento { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string TipoDocumento { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string EndPointUrl { get; set; }
    }
}