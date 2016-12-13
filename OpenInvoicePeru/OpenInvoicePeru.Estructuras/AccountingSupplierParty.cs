using System;

namespace OpenInvoicePeru.Estructuras
{
    [Serializable]
    public class AccountingSupplierParty
    {
        public string CustomerAssignedAccountId { get; set; }
        public string AdditionalAccountId { get; set; }
        public Party Party { get; set; }

    }
}