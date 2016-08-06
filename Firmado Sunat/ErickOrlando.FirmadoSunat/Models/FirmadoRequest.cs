namespace OpenInvoicePeru.FirmadoSunat.Models
{
    public class FirmadoRequest
    {
        public string CertificadoDigital { get; set; }
        public string PasswordCertificado { get; set; }
        public string TramaXmlSinFirma { get; set; }
        public bool UnSoloNodoExtension { get; set; }
    }
}
