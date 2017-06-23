namespace OpenInvoicePeru.ViewModel
{
    public class ConfiguracionViewModel
    {
        public string NumeroRuc { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string CodigoUbigeo { get; set; }
        public decimal TasaIgv { get; set; }
        public decimal TasaIsc { get; set; }
        public decimal TasaDetraccion { get; set; }
        public string CertificadoDigital { get; set; }
        public string ClaveCertificado { get; set; }
        public string UsuarioSol { get; set; }
        public string ClaveSol { get; set; }

        public bool Guardar()
        {
            return true;
        }

        public void Cancelar()
        {
            
        }
    }
}
