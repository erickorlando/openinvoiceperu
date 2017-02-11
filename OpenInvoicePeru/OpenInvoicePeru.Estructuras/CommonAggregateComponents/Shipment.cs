using System;
using System.Collections.Generic;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class Shipment
    {
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

        public Shipment()
        {
            GrossWeightMeasure = new InvoicedQuantity();
            ShipmentStages = new List<ShipmentStage>();
            DeliveryAddress = new PostalAddress();
            TransportHandlingUnit = new TransportHandlingUnit();
            OriginAddress = new PostalAddress();
        }
    }
}