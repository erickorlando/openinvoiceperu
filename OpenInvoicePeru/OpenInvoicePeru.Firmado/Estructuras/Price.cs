using System;

namespace OpenInvoicePeru.Firmado.Estructuras
{
    [Serializable]
    public class Price
    {
        public PayableAmount PriceAmount { get; set; }

        public Price()
        {
            PriceAmount = new PayableAmount();
        }
    }
}