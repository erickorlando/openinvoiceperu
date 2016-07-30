namespace OpenInvoicePeru.FirmadoSunat.Models
{
    public class SendBillResponse : RespuestaComun
    {
        public string CodigoRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }
        public string TramaZipCdr { get; set; }
    }
}
