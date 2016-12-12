using System;

namespace OpenInvoicePeru.Estructuras
{
    [Serializable]
    public class PartyIdentification
    {
        public PartyIdentificationId Id { get; set; }

        public PartyIdentification()
        {
            Id = new PartyIdentificationId();
        }
    }
}