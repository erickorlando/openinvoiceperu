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

        public Delivery Delivery { get; set; }

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

    [Serializable]
    public class Delivery
    {
        public Despatch Despatch { get; set; }
        public Despatch DeliveryLocation { get; set; }
        public List<DeliveryTerms> DeliveryTerms { get; set; }
        public Shipment Shipment { get; set; }

        public Delivery()
        {
            Despatch = new Despatch();
            DeliveryLocation = new Despatch();
            DeliveryTerms = new List<DeliveryTerms>();
            Shipment = new Shipment();
        }
    }

    [Serializable]
    public class DeliveryTerms
    {
        public string Id { get; set; }
        public PayableAmount Amount { get; set; }
    }

    [Serializable]
    public class Despatch
    {
        public DespatchAddress DespatchAddress { get; set; }
        public string Instructions { get; set; }

    }

    [Serializable]
    public class DespatchAddress
    {
        public string Id { get; set; }
        public string AddressLine { get; set; }
    }
}