using System;
using System.Collections.Generic;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class InvoiceLine
    {
        public int Id { get; set; }

        public InvoicedQuantity CreditedQuantity { get; set; }

        public InvoicedQuantity InvoicedQuantity { get; set; }

        public InvoicedQuantity DebitedQuantity { get; set; }

        public PayableAmount LineExtensionAmount { get; set; }

        public PricingReference PricingReference { get; set; }

        public AllowanceCharge AllowanceCharge { get; set; }

        public List<TaxTotal> TaxTotals { get; set; }

        public Item Item { get; set; }

        public Price Price { get; set; }

        public InvoiceLine()
        {
            CreditedQuantity = new InvoicedQuantity();
            InvoicedQuantity = new InvoicedQuantity();
            DebitedQuantity = new InvoicedQuantity();
            LineExtensionAmount = new PayableAmount();
            PricingReference = new PricingReference();
            AllowanceCharge = new AllowanceCharge();
            TaxTotals = new List<TaxTotal>();
            Item = new Item();
            Price = new Price();
        }
    }
}