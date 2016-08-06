namespace OpenInvoicePeru.FirmadoSunat.Models
{
    public class DetalleDocumento
    {
        public int Id { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Suma { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string TipoPrecio { get; set; }
        public decimal Impuesto { get; set; }
        public string TipoImpuesto { get; set; }
        public decimal ImpuestoSelectivo { get; set; }
        public decimal OtroImpuesto { get; set; }
        public string Descripcion { get; set; }
        public string CodigoItem { get; set; }
        public decimal PrecioReferencial { get; set; }
    }
}