namespace OpenInvoicePeru.FirmadoSunat.Models
{
    public abstract class DocumentoResumenDetalle
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string Serie { get; set; }
    }
}
