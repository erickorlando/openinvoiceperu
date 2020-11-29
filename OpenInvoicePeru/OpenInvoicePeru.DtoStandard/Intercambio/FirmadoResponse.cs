namespace OpenInvoicePeru.DtoStandard.Intercambio
{
    public class FirmadoResponse : RespuestaComun
    {
        public string TramaXmlFirmado { get; set; }

        public string ResumenFirma { get; set; }

        public string ValorFirma { get; set; }

        public string CodigoQr { get; set; }
    }
}