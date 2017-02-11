using System;

namespace OpenInvoicePeru.Estructuras.SunatAggregateComponents
{
    [Serializable]
    public class AdditionalProperty
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}