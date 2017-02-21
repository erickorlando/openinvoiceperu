using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenInvoicePeru.Entidades
{
    public class CabeceraDocumento : EntidadBase
    {
        public string IdDocumento { get; set; }

        public int IdTipoDocumento { get; set; }

        [ForeignKey(nameof(IdTipoDocumento))]
        public TipoDocumento TipoDocumento { get; set; }

        public int IdEmisor { get; set; }

        [ForeignKey(nameof(IdEmisor))]
        public Contribuyente Emisor { get; set; }

        public int IdReceptor { get; set; }

        [ForeignKey(nameof(IdReceptor))]
        public Contribuyente Receptor { get; set; }

        public int IdMoneda { get; set; }

        [ForeignKey(nameof(IdMoneda))]
        public Moneda Moneda { get; set; }

        public int IdTipoOperacion { get; set; }

        [ForeignKey(nameof(IdTipoOperacion))]
        public TipoOperacion TipoOperacion { get; set; }

        public decimal Gravadas { get; set; }

        public decimal Gratuitas { get; set; }

        public decimal Inafectas { get; set; }

        public decimal Exoneradas { get; set; }

        public decimal DescuentoGlobal { get; set; }

        public decimal TotalVenta { get; set; }

        public decimal TotalIgv { get; set; }

        public decimal TotalIsc { get; set; }

        public decimal TotalOtrosTributos { get; set; }

        public string MontoEnLetras { get; set; }

        public string PlacaVehiculo { get; set; }

        public decimal MontoPercepcion { get; set; }

        public decimal MontoDetraccion { get; set; }

        public int? IdDocumentoAnticipo { get; set; }

        public int? IdGuiaTransportista { get; set; }

        public ICollection<DetalleDocumento> Detalles { get; set; }

    }
}