#if !SILVERLIGHT
using Newtonsoft.Json;
#endif
namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class ConsultaConstanciaRequest : EnvioDocumentoComun
    {
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string Serie { get; set; }
#if !SILVERLIGHT

        [JsonProperty(Required = Required.Always)] 
#endif
        public int Numero { get; set; }
    }
}