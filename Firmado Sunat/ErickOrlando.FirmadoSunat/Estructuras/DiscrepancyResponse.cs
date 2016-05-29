using System;

namespace ErickOrlando.FirmadoSunat.Estructuras
{
    [Serializable]
    public class DiscrepancyResponse : IEquatable<DiscrepancyResponse>
    {
        public string ReferenceID { get; set; }
        public string ResponseCode { get; set; }
        public string Description { get; set; }

        public DiscrepancyResponse()
        {
            ReferenceID = string.Empty;
        }
        public bool Equals(DiscrepancyResponse other)
        {
            if (string.IsNullOrEmpty(ReferenceID))
                return false;

            return ReferenceID.Equals(other.ReferenceID);
        }

        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(ReferenceID))
                return base.GetHashCode();

            return ReferenceID.GetHashCode();
        }
    }
}