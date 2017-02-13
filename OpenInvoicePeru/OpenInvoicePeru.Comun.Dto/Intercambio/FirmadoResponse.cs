namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class FirmadoResponse : RespuestaComun
    {
        public string TramaXmlFirmado { get; set; }

        public string ResumenFirma { get; set; }

        public string ValorFirma { get; set; }
    }
}