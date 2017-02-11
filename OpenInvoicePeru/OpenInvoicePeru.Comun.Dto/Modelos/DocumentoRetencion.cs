using Newtonsoft.Json;
using OpenInvoicePeru.Comun.Dto.Contratos;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoRetencion : IDocumentoElectronico
    {
        [JsonProperty(Required = Required.Always)]
        public string IdDocumento { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string FechaEmision { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Contribuyente Emisor { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Contribuyente Receptor { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Moneda { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string RegimenRetencion { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TasaRetencion { get; set; }

        public string Observaciones { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal ImporteTotalRetenido { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal ImporteTotalPagado { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<ItemRetencion> DocumentosRelacionados { get; set; }
    }
}