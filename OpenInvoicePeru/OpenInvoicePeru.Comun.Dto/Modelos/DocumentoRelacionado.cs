using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoRelacionado
    {
        [JsonProperty(Required = Required.Always)]
        public string NroDocumento { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoDocumento { get; set; }
    }
}