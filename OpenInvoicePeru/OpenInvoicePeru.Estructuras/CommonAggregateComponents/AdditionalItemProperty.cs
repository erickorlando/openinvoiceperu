using System;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
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
}