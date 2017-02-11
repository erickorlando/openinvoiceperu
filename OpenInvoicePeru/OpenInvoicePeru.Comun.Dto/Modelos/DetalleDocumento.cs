using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DetalleDocumento
    {
        [JsonProperty(Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal Cantidad { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string UnidadMedida { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string CodigoItem { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Descripcion { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal PrecioUnitario { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal PrecioReferencial { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoPrecio { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoImpuesto { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal Impuesto { get; set; }

        public decimal ImpuestoSelectivo { get; set; }

        public decimal OtroImpuesto { get; set; }

        public decimal Descuento { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalVenta { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal Suma { get; set; }

        public DetalleDocumento()
        {
            Id = 1;
            UnidadMedida = "NIU";
            TipoPrecio = "01";
            TipoImpuesto = "10";
        }
    }
}