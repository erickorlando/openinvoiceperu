using System.ComponentModel.DataAnnotations.Schema;

namespace OpenInvoicePeru.Entidades
{
    public class DetalleDocumento : EntidadBase
    {
        public int IdCabeceraDocumento { get; set; }

        [ForeignKey(nameof(IdCabeceraDocumento))]
        public CabeceraDocumento Cabecera { get; set; }

        public decimal Cantidad { get; set; }

        public int IdUnidadMedida { get; set; }

        [ForeignKey(nameof(IdUnidadMedida))]
        public UnidadMedida UnidadMedida { get; set; }

        public string CodigoItem { get; set; }

        public string Descripcion { get; set; }

        public decimal PrecioUnitario { get; set; }

        public int IdTipoPrecio { get; set; }

        [ForeignKey(nameof(IdTipoPrecio))]
        public TipoPrecio TipoPrecio { get; set; }

        public decimal Impuesto { get; set; }

        public decimal ImpuestoSelectivo { get; set; }

        public decimal OtroImpuesto { get; set; }

        public decimal Descuento { get; set; }

        public decimal TotalVenta { get; set; }
    }
}