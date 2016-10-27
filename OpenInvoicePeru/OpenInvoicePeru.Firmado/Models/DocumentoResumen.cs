namespace OpenInvoicePeru.Firmado.Models
{
    public abstract class DocumentoResumen
    {
        public Contribuyente Emisor { get; set; }
        public string IdDocumento { get; set; }
        public string FechaEmision { get; set; }
        public string FechaReferencia { get; set; }
    }
}
