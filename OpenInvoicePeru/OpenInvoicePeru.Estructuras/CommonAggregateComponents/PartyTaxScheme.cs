using System;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class PartyTaxScheme
    {
        public string RegistrationName { get; set; }

        public CompanyId CompanyId { get; set; }

        public RegistrationAddress RegistrationAddress { get; set; }

        public PartyTaxScheme()
        {
            CompanyId = new CompanyId();
            RegistrationAddress = new RegistrationAddress();
        }
    }
}