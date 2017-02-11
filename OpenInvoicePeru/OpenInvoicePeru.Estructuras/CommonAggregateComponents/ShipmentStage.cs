using System;
using OpenInvoicePeru.Estructuras.SunatAggregateComponents;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class ShipmentStage
    {
        public int Id { get; set; }

        public CarrierParty CarrierParty { get; set; }

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