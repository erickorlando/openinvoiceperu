using System;

namespace OpenInvoicePeru.Firmado.Estructuras
{
    [Serializable]
    public class ReceiverParty
    {
        public PartyIdentification PartyIdentification { get; set; }
        public PartyName PartyName { get; set; }
        public PostalAddress PostalAddress { get; set; }
        public PartyLegalEntity PartyLegalEntity { get; set; }

        public ReceiverParty()
        {
            PartyIdentification = new PartyIdentification();
            PartyName = new PartyName();
            PostalAddress = new PostalAddress();
            PartyLegalEntity = new PartyLegalEntity();
        }
    }
}