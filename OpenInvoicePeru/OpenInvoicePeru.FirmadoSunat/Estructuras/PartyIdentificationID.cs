using System;

namespace OpenInvoicePeru.Firmado.Estructuras
{
    [Serializable]
    public class PartyIdentificationID
    {
        public string schemeID { get; set; }
        public string value { get; set; }
    }
}