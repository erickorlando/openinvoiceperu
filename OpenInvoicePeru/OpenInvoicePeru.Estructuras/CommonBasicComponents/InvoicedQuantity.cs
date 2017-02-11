using System;

namespace OpenInvoicePeru.Estructuras.CommonBasicComponents
{
    [Serializable]
    public class InvoicedQuantity
    {
        public string UnitCode { get; set; }

        public decimal Value { get; set; }
    }
}