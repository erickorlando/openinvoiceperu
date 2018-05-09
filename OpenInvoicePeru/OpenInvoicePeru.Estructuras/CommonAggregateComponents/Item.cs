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
        public AdditionalItemProperty AdditionalItemProperty { get; set; }

        public Item()
        {
            SellersItemIdentification = new SellersItemIdentification();
            CommodityClassification = new CommodityClassification();
            StandardItemIdentification = new StandardItemIdentification();
            AdditionalItemProperty = new AdditionalItemProperty();
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
        public List<ItemValue> Values { get; set; }
    }

    public class ItemValue
    {
        public string Value { get; set; }
    }
}