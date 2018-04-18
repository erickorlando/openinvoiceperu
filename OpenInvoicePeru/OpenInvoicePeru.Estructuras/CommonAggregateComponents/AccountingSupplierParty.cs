using System;
using OpenInvoicePeru.Comun.Constantes;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class AccountingSupplierParty
    {
        public string CustomerAssignedAccountId { get; set; }

        public string AdditionalAccountId { get; set; }

        public Party Party { get; set; }

        public PartyTaxScheme PartyTaxScheme { get; set; }

        public AccountingSupplierParty()
        {
            Party = new Party();
            PartyTaxScheme = new PartyTaxScheme();
        }
    }

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

    [Serializable]
    public class RegistrationAddress
    {
        public string AddressTypeCode { get; set; }
    }

    [Serializable]
    public class CompanyId
    {
        public string SchemeId { get; set; }

        public string SchemeName { get; set; }

        public string SchemeAgencyName { get; set; }

        public string SchemeUri { get; set; }

        public string Value { get; set; }

        public CompanyId()
        {
            SchemeName = ValoresUbl.CompanySchemeName;
            SchemeAgencyName = ValoresUbl.SchemeAgencyName;
            SchemeUri = ValoresUbl.CompanySchemeUri;
        }
    }
}