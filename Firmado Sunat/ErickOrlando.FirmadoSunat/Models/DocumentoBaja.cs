namespace OpenInvoicePeru.FirmadoSunat.Models
{
    public class DocumentoBaja : DocumentoResumenDetalle
    {
        public string Correlativo { get; set; }
        public string MotivoBaja { get; set; }
    }
}
