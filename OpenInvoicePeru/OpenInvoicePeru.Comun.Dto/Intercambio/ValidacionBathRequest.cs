using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class ValidacionBathRequest
    {
        [JsonProperty(Required = Required.Always)]
        public string Token { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<ComprobanteRequest> Comprobantes { get; set; }

        public ValidacionBathRequest()
        {
            Comprobantes = new List<ComprobanteRequest>();
        }
    }
}