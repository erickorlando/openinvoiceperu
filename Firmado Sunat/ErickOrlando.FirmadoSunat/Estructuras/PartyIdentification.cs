using System;

namespace OpenInvoicePeru.FirmadoSunat.Estructuras
{
    [Serializable]
    public class PartyIdentification
    {
        public PartyIdentificationID ID { get; set; }

        public PartyIdentification()
        {
            ID = new PartyIdentificationID();
        }
    }
}