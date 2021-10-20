using Newtonsoft.Json;

namespace OpenInvoicePeru.RestService.ApiSunatDto
{
    public class ValidacionRequest
    {
        [JsonProperty(PropertyName = "numRuc")]
        public string RucEmisor { get; set; }
        
        [JsonProperty(PropertyName = "codComp")]
        public string CodigoComprobante { get; set; }
        
        [JsonProperty(PropertyName="numeroSerie")]
        public string NumeroSerie { get; set; }
        
        [JsonProperty(PropertyName = "numero")]
        public int Numero { get; set; }

        [JsonProperty(PropertyName = "fechaEmision")]
        public string FechaEmision { get; set; }

        [JsonProperty(PropertyName = "monto")]
        public decimal Monto { get; set; }
    }
}