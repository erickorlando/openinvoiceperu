using System;
using OpenInvoicePeru.Estructuras.CommonAggregateComponents;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;

namespace OpenInvoicePeru.Estructuras.SunatAggregateComponents
{
    [Serializable]
    public class SunatRetentionDocumentReference
    {
        public PartyIdentificationId Id { get; set; }

        public string IssueDate { get; set; }

        public PayableAmount TotalInvoiceAmount { get; set; }

        public Payment Payment { get; set; }

        public SunatRetentionInformation SunatRetentionInformation { get; set; }

        public SunatRetentionDocumentReference()
        {
            Id = new PartyIdentificationId();
            TotalInvoiceAmount = new PayableAmount();
            Payment = new Payment();
            SunatRetentionInformation = new SunatRetentionInformation();
        }
    }
}