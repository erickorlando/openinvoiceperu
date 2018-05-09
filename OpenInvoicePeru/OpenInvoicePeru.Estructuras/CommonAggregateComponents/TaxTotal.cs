using System;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class TaxTotal
    {
        public PayableAmount TaxAmount { get; set; }

        public TaxSubtotal TaxSubtotal { get; set; }

        public TaxTotal()
        {
            TaxAmount = new PayableAmount();
            TaxSubtotal = new TaxSubtotal();
        }
    }
}