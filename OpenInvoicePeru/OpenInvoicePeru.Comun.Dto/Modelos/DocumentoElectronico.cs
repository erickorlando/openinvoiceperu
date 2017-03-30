#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

using OpenInvoicePeru.Comun.Dto.Contratos;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoElectronico : IDocumentoElectronico
    {
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string IdDocumento { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string TipoDocumento { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public Contribuyente Emisor { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public Contribuyente Receptor { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string FechaEmision { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string Moneda { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.AllowNull)]
#endif
        public string TipoOperacion { get; set; }

        public decimal Gravadas { get; set; }

        public decimal Gratuitas { get; set; }

        public decimal Inafectas { get; set; }

        public decimal Exoneradas { get; set; }

        public decimal DescuentoGlobal { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public List<DetalleDocumento> Items { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal TotalVenta { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal TotalIgv { get; set; }

        public decimal TotalIsc { get; set; }

        public decimal TotalOtrosTributos { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string MontoEnLetras { get; set; }

        public string PlacaVehiculo { get; set; }

        public decimal MontoPercepcion { get; set; }

        public decimal MontoDetraccion { get; set; }

        public List<DatoAdicional> DatoAdicionales { get; set; }

        public string TipoDocAnticipo { get; set; }

        public string DocAnticipo { get; set; }

        public string MonedaAnticipo { get; set; }

        public decimal MontoAnticipo { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.AllowNull)]
#endif
        public DatosGuia DatosGuiaTransportista { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.AllowNull)]
#endif
        public List<DocumentoRelacionado> Relacionados { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.AllowNull)]
#endif
        public List<Discrepancia> Discrepancias { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal CalculoIgv { get; set; }

        public decimal CalculoIsc { get; set; }

        public decimal CalculoDetraccion { get; set; }

        public DocumentoElectronico()
        {
            Emisor = new Contribuyente
            {
                TipoDocumento = "6" // RUC.
            };
            Receptor = new Contribuyente
            {
                TipoDocumento = "6" // RUC.
            };
            CalculoIgv = 0.18m;
            CalculoIsc = 0.10m;
            CalculoDetraccion = 0.04m;
            Items = new List<DetalleDocumento>();
            DatoAdicionales = new List<DatoAdicional>();
            Relacionados = new List<DocumentoRelacionado>();
            Discrepancias = new List<Discrepancia>();
            TipoDocumento = "01"; // Factura.
            TipoOperacion = "01"; // Venta Interna.
            Moneda = "PEN"; // Soles.
        }
    }
}