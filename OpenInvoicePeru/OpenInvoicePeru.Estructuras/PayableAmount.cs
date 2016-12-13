using System;

namespace OpenInvoicePeru.Estructuras
{
    [Serializable]
    public class PayableAmount
    {
        public string CurrencyId { get; set; }
        public decimal Value { get; set; }
    }
}