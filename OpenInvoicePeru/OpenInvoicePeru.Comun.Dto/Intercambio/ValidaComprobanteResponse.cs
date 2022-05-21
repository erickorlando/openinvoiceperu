namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class ValidaComprobanteResponse : RespuestaComun
    {
        public string CodigoEstadoComprobante { get; set; }
        public string CodigoEstadoRuc { get; set; }
        public string CodigoEstadoDomicilio { get; set; }
        public string Observaciones { get; set; }
        
        public string EstadoComprobante { get; set; }
        public string EstadoRuc { get; set; }
        public string EstadoDomicilio { get; set; }
        
        public string NroCpe { get; set; }
    }
}