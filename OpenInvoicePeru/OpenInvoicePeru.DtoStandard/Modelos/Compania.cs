using Newtonsoft.Json;

namespace OpenInvoicePeru.DtoStandard.Modelos
{
    public class Compania : Contribuyente
    {
        [JsonProperty(Order = 5)]
        [JsonRequired]
        public string CodigoAnexo { get; set; }
    }
}