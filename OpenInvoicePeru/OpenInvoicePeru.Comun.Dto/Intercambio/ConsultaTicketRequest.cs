#if !SILVERLIGHT
using Newtonsoft.Json;
#endif
namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class ConsultaTicketRequest : EnvioDocumentoComun
    {
        #if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string NroTicket { get; set; }
    }
}