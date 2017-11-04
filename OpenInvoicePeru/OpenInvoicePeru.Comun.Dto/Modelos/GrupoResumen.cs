using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class GrupoResumen : DocumentoResumenDetalle
    {
        public int CorrelativoInicio { get; set; }

        public int CorrelativoFin { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Moneda { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalVenta { get; set; }

        public decimal TotalDescuentos { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalIgv { get; set; }

        public decimal TotalIsc { get; set; }

        public decimal TotalOtrosImpuestos { get; set; }

        public decimal Gravadas { get; set; }

        public decimal Exoneradas { get; set; }

        public decimal Inafectas { get; set; }

        public decimal Exportacion { get; set; }

        public decimal Gratuitas { get; set; }
    }
}