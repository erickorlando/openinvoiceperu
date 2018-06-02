using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Compania : Contribuyente
    {
        [JsonProperty(Order = 5)]
        [JsonRequired]
        public string CodigoAnexo { get; set; }
    }
}