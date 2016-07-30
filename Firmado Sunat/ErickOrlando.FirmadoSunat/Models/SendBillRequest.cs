namespace OpenInvoicePeru.FirmadoSunat.Models
{
    public class SendBillRequest
    {
        public string TramaXmlFirmado { get; set; }
        public string Ruc { get; set; }
        public string UsuarioSol { get; set; }
        public string ClaveSol { get; set; }
        public string TipoDocumento { get; set; }
        public string IdDocumento { get; set; }
        public string EndPointUrl { get; set; }
    }
}
