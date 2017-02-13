using System;
using System.Collections.Generic;
using OpenInvoicePeru.Estructuras.CommonAggregateComponents;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;

namespace OpenInvoicePeru.Estructuras.SunatAggregateComponents
{
    [Serializable]
    public class VoidedDocumentsLine
    {
        public int LineId { get; set; }

        public string DocumentTypeCode { get; set; }

        public string DocumentSerialId { get; set; }

        public int DocumentNumberId { get; set; }

        public string VoidReasonDescription { get; set; }

        // A partir de aqui son los datos para el resumen diario.
        public string Id { get; set; }

        public int StartDocumentNumberId { get; set; }

        public int EndDocumentNumberId { get; set; }

        public PayableAmount TotalAmount { get; set; }

        public List<BillingPayment> BillingPayments { get; set; }

        public AllowanceCharge AllowanceCharge { get; set; }

        public List<TaxTotal> TaxTotals { get; set; }

        public AccountingSupplierParty AccountingCustomerParty { get; set; }

        public BillingReference BillingReference { get; set; }

        public int? ConditionCode { get; set; }

        public VoidedDocumentsLine()
        {
            TotalAmount = new PayableAmount();
            BillingPayments = new List<BillingPayment>();
            AllowanceCharge = new AllowanceCharge();
            TaxTotals = new List<TaxTotal>();
            AccountingCustomerParty = new AccountingSupplierParty();
            BillingReference = new BillingReference();
        }
    }
}