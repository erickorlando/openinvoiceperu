namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class ValidaComprobanteRequest
    {
        public string RucEmisor { get; set; }

        public string RucReceptor { get; set; }

        public string TipoComprobante { get; set; }
        
        public string NumeroSerie { get; set; }
        
        public int Numero { get; set; }

        public string FechaEmision { get; set; }

        public decimal Monto { get; set; }

        public string Token { get; set; }
    }
}