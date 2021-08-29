using System;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class DespatchAddress
    {
        public string Id { get; set; }
        public string AddressLine { get; set; }
    }
}