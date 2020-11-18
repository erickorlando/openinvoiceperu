using Newtonsoft.Json;
using OpenInvoicePeru.DtoStandard.Contratos;

namespace OpenInvoicePeru.DtoStandard.Modelos
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