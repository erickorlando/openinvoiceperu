using System;

namespace ErickOrlando.FirmadoSunat.Estructuras
{
    [Serializable]
    public class BillingPayment
    {
        public PayableAmount PaidAmount { get; set; }
        public string InstructionID { get; set; }

        public BillingPayment()
        {
            PaidAmount = new PayableAmount();
        }
    }
}