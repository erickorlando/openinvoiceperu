#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DetalleDocumento
    {
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public int Id { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal Cantidad { get; set; }

#if !SILVERLIGHT
    [JsonProperty(Required = Required.Always)]
#endif
        public string UnidadMedida { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string CodigoItem { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string Descripcion { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal PrecioUnitario { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal PrecioReferencial { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string TipoPrecio { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string TipoImpuesto { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal Impuesto { get; set; }

        public decimal ImpuestoSelectivo { get; set; }

        public decimal OtroImpuesto { get; set; }

        public decimal Descuento { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal TotalVenta { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
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