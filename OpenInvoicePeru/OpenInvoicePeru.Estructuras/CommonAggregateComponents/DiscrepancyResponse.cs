using System;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class DiscrepancyResponse : IEquatable<DiscrepancyResponse>
    {
        public string ReferenceId { get; set; }

        public string ResponseCode { get; set; }

        public string Description { get; set; }

        public DiscrepancyResponse()
        {
            ReferenceId = string.Empty;
        }

        public bool Equals(DiscrepancyResponse other)
        {
            if (string.IsNullOrEmpty(ReferenceId))
                return false;

            return ReferenceId.Equals(other.ReferenceId);
        }

        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(ReferenceId))
                return base.GetHashCode();

            return ReferenceId.GetHashCode();
        }
    }
}