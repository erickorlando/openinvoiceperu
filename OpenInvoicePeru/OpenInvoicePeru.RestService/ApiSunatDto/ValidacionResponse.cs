using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenInvoicePeru.RestService.ApiSunatDto
{
    public class ValidacionResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty(PropertyName = "estadoCp")]
        public string EstadoComprobante { get; set; }

        [JsonProperty(PropertyName = "estadoRuc")]
        public string EstadoRuc { get; set; }

        [JsonProperty(PropertyName = "condDomiRuc")]
        public string CondicionDomicilio { get; set; }

        [JsonProperty(PropertyName = "observaciones")]
        public ICollection<string> Observaciones { get; set; }
    }
}