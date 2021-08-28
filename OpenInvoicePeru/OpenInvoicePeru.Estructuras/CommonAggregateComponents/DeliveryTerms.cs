using System;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class DeliveryTerms
    {
        public string Id { get; set; }
        public PayableAmount Amount { get; set; }
    }
}