#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class GrupoResumen : DocumentoResumenDetalle
    {

        public int CorrelativoInicio { get; set; }

        public int CorrelativoFin { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string Moneda { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal TotalVenta { get; set; }

        public decimal TotalDescuentos { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
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