using System;
using System.Collections.Generic;

namespace ErickOrlando.FirmadoSunat.Estructuras
{
    [Serializable]
    public class VoidedDocumentsLine
    {
        public int LineID { get; set; }
        public string DocumentTypeCode { get; set; }
        public string DocumentSerialID { get; set; }
        public int DocumentNumberID { get; set; }
        public string VoidReasonDescription { get; set; }
        // A partir de aqui son los datos para el resumen diario.
        public int StartDocumentNumberID { get; set; }
        public int EndDocumentNumberID { get; set; }
        public PayableAmount TotalAmount { get; set; }
        public List<BillingPayment> BillingPayments { get; set; }
        public AllowanceCharge AllowanceCharge { get; set; }
        public List<TaxTotal> TaxTotals { get; set; }

        public VoidedDocumentsLine()
        {
            TotalAmount = new PayableAmount();
            BillingPayments = new List<BillingPayment>();
            AllowanceCharge = new AllowanceCharge();
            TaxTotals = new List<TaxTotal>();
        }
    }
}