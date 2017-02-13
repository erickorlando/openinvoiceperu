using System;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
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