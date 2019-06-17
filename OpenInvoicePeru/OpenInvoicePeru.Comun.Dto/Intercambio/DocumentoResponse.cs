namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class DocumentoResponse : RespuestaComun
    {
        public string TramaXmlSinFirma { get; set; }

        public string ValoresParaQr { get; set; }
    }
}