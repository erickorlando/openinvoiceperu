using System;
using System.Collections.Generic;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class TransportHandlingUnit
    {
        public string Id { get; set; }

        public List<TransportEquipment> TransportEquipments { get; set; }

        public List<MeasurementDimension> MeasurementDimensions { get; set; }

        public TransportHandlingUnit()
        {
            TransportEquipments = new List<TransportEquipment>();
        }
    }

    [Serializable]
    public class MeasurementDimension
    {
        public string AttributeId { get; set; }
        public decimal Measure { get; set; }

    }
}