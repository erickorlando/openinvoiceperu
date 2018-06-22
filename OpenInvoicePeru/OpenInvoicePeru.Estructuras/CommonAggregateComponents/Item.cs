using System;
using System.Collections.Generic;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class Item
    {
        public string Description { get; set; }

        public SellersItemIdentification SellersItemIdentification { get; set; }

        public CommodityClassification CommodityClassification { get; set; }

        public StandardItemIdentification StandardItemIdentification { get; set; }

        public List<AdditionalItemProperty> AdditionalItemProperties { get; set; }

        public Item()
        {
            SellersItemIdentification = new SellersItemIdentification();
            CommodityClassification = new CommodityClassification();
            StandardItemIdentification = new StandardItemIdentification();
            AdditionalItemProperties = new List<AdditionalItemProperty>();
        }
    }

    [Serializable]
    public class SellersItemIdentification
    {
        public string Id { get; set; }
    }

    [Serializable]
    public class CommodityClassification
    {
        public string ItemClassificationCode { get; set; }
    }

    [Serializable]
    public class StandardItemIdentification
    {
        public string Id { get; set; }
    }

    [Serializable]
    public class AdditionalItemProperty
    {
        public string Name { get; set; }

        public string NameCode { get; set; }

        public string Value { get; set; }

        public UsabilityPeriod UsabilityPeriod { get; set; }

        public AdditionalItemProperty()
        {
            UsabilityPeriod = new UsabilityPeriod();
        }
    }

    [Serializable]
    public class UsabilityPeriod
    {
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public int DurationMeasure { get; set; }
    }
}