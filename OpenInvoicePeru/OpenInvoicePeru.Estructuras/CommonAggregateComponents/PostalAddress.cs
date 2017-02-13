using System;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class PostalAddress
    {
        public string Id { get; set; }

        public string StreetName { get; set; }

        public string CitySubdivisionName { get; set; }

        public string CityName { get; set; }

        public string CountrySubentity { get; set; }

        public string District { get; set; }

        public Country Country { get; set; }

        public PostalAddress()
        {
            Country = new Country();
        }
    }
}