using Newtonsoft.Json;

using OpenInvoicePeru.Comun.Dto.Contratos;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public abstract class DocumentoResumen : IDocumentoElectronico
    {
        [JsonProperty(Required = Required.Always)]
        public string IdDocumento { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string FechaEmision { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string FechaReferencia { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Contribuyente Emisor { get; set; }
    }
}