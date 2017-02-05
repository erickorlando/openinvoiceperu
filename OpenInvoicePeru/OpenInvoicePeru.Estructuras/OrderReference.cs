using System;

namespace OpenInvoicePeru.Estructuras
{
    [Serializable]
    public class OrderReference
    {
        public string Id { get; set; }

        public OrderTypeCode OrderTypeCode { get; set; }

        public OrderReference()
        {
            OrderTypeCode = new OrderTypeCode();
        }
    }
}