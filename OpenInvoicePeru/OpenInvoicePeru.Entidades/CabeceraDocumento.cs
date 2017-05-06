using System.Collections.Generic;

namespace OpenInvoicePeru.Entidades
{
    public class CabeceraDocumento : EntidadBase
    {
        public int IdTipoDocumento { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        public int IdEmisor { get; set; }

        public Contribuyente Emisor { get; set; }

        public int IdReceptor { get; set; }

        public Contribuyente Receptor { get; set; }

        public int IdMoneda { get; set; }

        public Moneda Moneda { get; set; }

        public int IdTipoOperacion { get; set; }

        public TipoOperacion TipoOperacion { get; set; }

        public int? IdDocumentoAnticipo { get; set; }

        public virtual DocumentoAnticipo DocumentoAnticipo { get; set; }

        public int? IdGuiaTransportista { get; set; }

        public virtual GuiaTransportista GuiaTransportista { get; set; }

        public string IdDocumento { get; set; }

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

        public ICollection<DetalleDocumento> Detalles { get; set; }

        public ICollection<DatoAdicional> DatoAdicionales { get; set; }

        public ICollection<DocumentoRelacionado> DocumentoRelacionados { get; set; }

        public ICollection<Discrepancia> Discrepancias { get; set; }
    }
}