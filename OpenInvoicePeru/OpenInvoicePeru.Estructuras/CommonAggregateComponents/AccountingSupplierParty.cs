using System;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class AccountingSupplierParty
    {
        public Party Party { get; set; }

        public PartyTaxScheme PartyTaxScheme { get; set; }

        public string CustomerAssignedAccountId { get; set; }

        public string AdditionalAccountId { get; set; }

        public AccountingSupplierParty()
        {
            Party = new Party();
        }
    }
}