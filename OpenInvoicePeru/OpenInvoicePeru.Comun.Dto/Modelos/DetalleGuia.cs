namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DetalleGuia
    {
        public int Correlativo { get; set; }

        public decimal Cantidad { get; set; }

        public string UnidadMedida { get; set; }

        public string Descripcion { get; set; }

        public string CodigoItem { get; set; }
    }
}