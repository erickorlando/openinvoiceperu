using System;

namespace OpenInvoicePeru.Estructuras
{
    [Serializable]
    public class BillingPayment
    {
        public PartyIdentificationId Id { get; set; }
        public PayableAmount PaidAmount { get; set; }
        public string InstructionId { get; set; }

        public BillingPayment()
        {
            PaidAmount = new PayableAmount();
            Id = new PartyIdentificationId();
        }
    }
}