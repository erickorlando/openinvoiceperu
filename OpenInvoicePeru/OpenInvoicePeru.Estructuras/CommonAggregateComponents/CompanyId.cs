using System;
using OpenInvoicePeru.Comun.Constantes;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
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