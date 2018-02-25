using System;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class Item
    {
        public string Description { get; set; }

        public SellersItemIdentification SellersItemIdentification { get; set; }

        public AdditionalItemIdentification AdditionalItemIdentification { get; set; }

        public Item()
        {
            SellersItemIdentification = new SellersItemIdentification();

            AdditionalItemIdentification = new AdditionalItemIdentification();
        }
    }

    [Serializable]
    public class SellersItemIdentification
    {
        public string Id { get; set; }
    }

    [Serializable]
    public class AdditionalItemIdentification
    {
        public string Id { get; set; }
    }
}