using System;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class MeasurementDimension
    {
        public string AttributeId { get; set; }
        public decimal Measure { get; set; }

    }
}