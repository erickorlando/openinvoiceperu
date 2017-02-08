using System;

namespace OpenInvoicePeru.Estructuras
{
    [Serializable]
    public class CarrierParty
    {
        public PartyIdentification PartyIdentification { get; set; }

        public PartyLegalEntity PartyLegalEntity { get; set; }

        public CarrierParty()
        {
            PartyIdentification = new PartyIdentification();
            PartyLegalEntity = new PartyLegalEntity();
        }
    }
}