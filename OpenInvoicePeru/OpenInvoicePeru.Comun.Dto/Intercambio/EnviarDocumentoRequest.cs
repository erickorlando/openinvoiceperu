#if !SILVERLIGHT
using Newtonsoft.Json;
#endif
namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class EnviarDocumentoRequest : EnvioDocumentoComun
    {
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string TramaXmlFirmado { get; set; }
    }
}