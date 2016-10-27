using System;

namespace OpenInvoicePeru.Firmado.Estructuras
{
    [Serializable]
    public class AllowanceCharge
    {
        public bool ChargeIndicator { get; set; }
        public PayableAmount Amount { get; set; }

        public AllowanceCharge()
        {
            Amount = new PayableAmount();
        }
    }
}