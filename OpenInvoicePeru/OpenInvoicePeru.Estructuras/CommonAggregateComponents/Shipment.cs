using System;
using System.Collections.Generic;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class Shipment
    {
        public Consignment Consignment { get; set; }

        public string HandlingCode { get; set; }

        public string Information { get; set; }

        public bool SplitConsignmentIndicator { get; set; }

        public InvoicedQuantity GrossWeightMeasure { get; set; }

        public int TotalTransportHandlingUnitQuantity { get; set; }

        public List<ShipmentStage> ShipmentStages { get; set; }

        public PostalAddress DeliveryAddress { get; set; }

        public TransportHandlingUnit TransportHandlingUnit { get; set; }

        public PostalAddress OriginAddress { get; set; }

        /// <remarks>
        /// cac:FirstArrivalPortLocation/cbc:ID
        /// </remarks>>
        public string FirstArrivalPortLocationId { get; set; }

        public string Id { get; set; }

        public Shipment()
        {
            Consignment = new Consignment();
            GrossWeightMeasure = new InvoicedQuantity();
            ShipmentStages = new List<ShipmentStage>();
            DeliveryAddress = new PostalAddress();
            TransportHandlingUnit = new TransportHandlingUnit();
            OriginAddress = new PostalAddress();
        }
    }

    [Serializable]
    public class Consignment
    {
        public PlannedPickupTransportEvent PlannedPickupTransportEvent { get; set; }
        public string CarrierServiceInstructions { get; set; }
        public string Id { get; set; }
        public DeliveryTerms DeliveryTerms { get; set; }
        public TransportHandlingUnit TransportHandlingUnit { get; set; }
        public decimal DeclaredForCarriageValueAmount { get; set; }

        public Consignment()
        {
            DeliveryTerms = new DeliveryTerms();
            PlannedPickupTransportEvent = new PlannedPickupTransportEvent();
            TransportHandlingUnit = new TransportHandlingUnit();
        }
    }

    [Serializable]
    public class PlannedPickupTransportEvent
    {
        public string LocationId { get; set; }
    }
}