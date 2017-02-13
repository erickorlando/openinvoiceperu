using System;
using System.Collections.Generic;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class PricingReference
    {
        public List<AlternativeConditionPrice> AlternativeConditionPrices { get; set; }

        public PricingReference()
        {
            AlternativeConditionPrices = new List<AlternativeConditionPrice>();
        }
    }
}