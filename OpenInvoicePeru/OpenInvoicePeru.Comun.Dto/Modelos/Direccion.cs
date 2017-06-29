#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Direccion
    {
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string Ubigeo { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string DireccionCompleta { get; set; }
    }
}