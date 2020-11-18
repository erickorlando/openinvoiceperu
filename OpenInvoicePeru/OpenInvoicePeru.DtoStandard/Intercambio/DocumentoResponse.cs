namespace OpenInvoicePeru.DtoStandard.Intercambio
{
    public class DocumentoResponse : RespuestaComun
    {
        public string TramaXmlSinFirma { get; set; }

        public string ValoresParaQr { get; set; }

    }
}