using System.Collections.Generic;

namespace OpenInvoicePeru.FirmadoSunat.Models
{
    public class DocumentoElectronico
    {

        public string TipoDocumento { get; set; }

        public Contribuyente Emisor { get; set; }
        public Contribuyente Receptor { get; set; }

        public string IdDocumento { get; set; }
        public string FechaEmision { get; set; }
        public string Moneda { get; set; }

        public decimal Gravadas { get; set; }
        public decimal NoGravadas { get; set; }
        public decimal Gratuitas { get; set; }
        public decimal Inafectas { get; set; }
        public decimal Exoneradas { get; set; }

        public decimal TotalVenta { get; set; }
        public decimal TotalIgv { get; set; }
        public decimal TotalIsc { get; set; }
        public decimal TotalOtrosTributos { get; set; }

        public string MontoEnLetras { get; set; }
        public string TipoOperacion { get; set; }

        public ICollection<DetalleDocumento> Items { get; set; }
    }

}