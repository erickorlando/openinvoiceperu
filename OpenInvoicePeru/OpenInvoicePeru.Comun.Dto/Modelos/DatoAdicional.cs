#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DatoAdicional
    {
#if !SILVERLIGHT
        [JsonProperty(Order = 1, Required = Required.Always)]
#endif
        public string Codigo { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 2, Required = Required.Always)]
#endif
        public string Contenido { get; set; }
    }
}