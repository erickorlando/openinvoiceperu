using System;

namespace OpenInvoicePeru.Firmado.Estructuras
{
    [Serializable]
    public class AlternativeConditionPrice
    {
        public PayableAmount PriceAmount { get; set; }
        public string PriceTypeCode { get; set; }

        public AlternativeConditionPrice()
        {
            PriceAmount = new PayableAmount();
        }
    }
}