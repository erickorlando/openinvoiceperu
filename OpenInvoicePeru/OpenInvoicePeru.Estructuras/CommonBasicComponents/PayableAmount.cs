using System;

namespace OpenInvoicePeru.Estructuras.CommonBasicComponents
{
    [Serializable]
    public class PayableAmount
    {
        public string CurrencyId { get; set; }

        public decimal Value { get; set; }
    }
}