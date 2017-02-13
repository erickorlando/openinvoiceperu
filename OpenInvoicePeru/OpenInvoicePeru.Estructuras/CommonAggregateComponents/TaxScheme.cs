using System;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class TaxScheme
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string TaxTypeCode { get; set; }
    }
}