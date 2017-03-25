#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Discrepancia
    {
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string NroReferencia { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string Tipo { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string Descripcion { get; set; }
    }
}