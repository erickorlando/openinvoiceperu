using System;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class TaxSubtotal
    {
        public PayableAmount TaxableAmount { get; set; }

        public PayableAmount TaxAmount { get; set; }

        public TaxCategory TaxCategory { get; set; }

        public InvoicedQuantity BaseUnitMeasure { get; set; }

        public TaxSubtotal()
        {
            TaxableAmount = new PayableAmount();
            TaxAmount = new PayableAmount();
            TaxCategory = new TaxCategory();            
            BaseUnitMeasure = new InvoicedQuantity();
        }
    }
}