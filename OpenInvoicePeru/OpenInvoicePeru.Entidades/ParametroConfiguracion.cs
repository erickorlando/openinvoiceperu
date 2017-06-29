namespace OpenInvoicePeru.Entidades
{
    public class ParametroConfiguracion : EntidadBase
    {
        public int IdContribuyente { get; set; }

        public Empresa Contribuyente { get; set; }

        public decimal TasaIgv { get; set; }

        public decimal TasaIsc { get; set; }

        public decimal TasaDetraccion { get; set; }

        public string CertificadoDigital { get; set; }

        public string ClaveCertificado { get; set; }

        public string UsuarioSol { get; set; }

        public string ClaveSol { get; set; }
    }
}