using System;
using OpenInvoicePeru.Comun.Constantes;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class AccountingSupplierParty
    {
        public Party Party { get; set; }

        public AccountingSupplierParty()
        {
            Party = new Party();
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
        public AddressLine AddressLine { get; set; }
        public string CitySubdivisionName { get; set; }
        public string CityName { get; set; }
        public string ID { get; set; }
        public string CountrySubentity { get; set; }
        public string District { get; set; }
        public Country Country { get; set; }

        public RegistrationAddress()
        {
            AddressLine = new AddressLine();
            Country = new Country();
        }
    }

    [Serializable]
    public class AddressLine
    {
        public string Line { get; set; }
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