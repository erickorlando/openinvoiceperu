using System;

namespace OpenInvoicePeru.Estructuras
{
    [Serializable]
    public class ShipmentStage
    {
        public PartyIdentification CarrierParty { get; set; }

        public PartyIdentification DriverPerson { get; set; }

        public string TransportModeCode { get; set; }

        /// <remarks>
        /// cac:TransitPeriod/cbc:StartDate
        /// </remarks>>
        public DateTime TransitPeriodStartPeriod { get; set; }

        public SunatRoadTransport TransportMeans { get; set; }

        public ShipmentStage()
        {
            DriverPerson = new PartyIdentification();
            TransportMeans = new SunatRoadTransport();
        }
    }
}