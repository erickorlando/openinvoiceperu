using System;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class Item
    {
        public string Description { get; set; }

        public SellersItemIdentification SellersItemIdentification { get; set; }

        public Item()
        {
            SellersItemIdentification = new SellersItemIdentification();
        }
    }

    [Serializable]
    public class SellersItemIdentification
    {
        public string Id { get; set; }
    }
}