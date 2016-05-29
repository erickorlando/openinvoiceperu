using System;
using System.Collections.Generic;

namespace ErickOrlando.FirmadoSunat.Estructuras
{
    [Serializable]
    public class AdditionalInformation
    {
        public List<AdditionalMonetaryTotal> AdditionalMonetaryTotals { get; set; }
        public List<AdditionalProperty> AdditionalProperties { get; set; }

        public SunatTransaction SunatTransaction { get; set; }

        public AdditionalInformation()
        {
            AdditionalMonetaryTotals = new List<AdditionalMonetaryTotal>();
            AdditionalProperties = new List<AdditionalProperty>();
            SunatTransaction = new SunatTransaction();
        }
    }

    public class SunatTransaction
    {
        public string Id { get; set; }
    }
}