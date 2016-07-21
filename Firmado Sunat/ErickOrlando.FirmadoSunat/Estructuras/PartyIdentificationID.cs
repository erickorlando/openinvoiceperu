using System;

namespace OpenInvoicePeru.FirmadoSunat.Estructuras
{
    [Serializable]
    public class PartyIdentificationID
    {
        public string schemeID { get; set; }
        public string value { get; set; }
    }
}