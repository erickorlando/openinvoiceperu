using System;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class RegistrationAddress
    {
        public string AddressTypeCode { get; set; }
        public AddressLine AddressLine { get; set; }
        public string CitySubdivisionName { get; set; }
        public string CityName { get; set; }
        public string Id { get; set; }
        public string CountrySubentity { get; set; }
        public string District { get; set; }
        public Country Country { get; set; }

        public RegistrationAddress()
        {
            AddressLine = new AddressLine();
            Country = new Country();
        }
    }
}