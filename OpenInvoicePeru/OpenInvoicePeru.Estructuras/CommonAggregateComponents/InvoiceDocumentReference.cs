using System;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class InvoiceDocumentReference : IEquatable<InvoiceDocumentReference>
    {
        public string Id { get; set; }

        public string DocumentTypeCode { get; set; }

        public InvoiceDocumentReference()
        {
            Id = string.Empty;
        }

        public bool Equals(InvoiceDocumentReference other)
        {
            if (other == null) return false;

            if (string.IsNullOrEmpty(Id))
                return false;
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(Id))
                return base.GetHashCode();

            return Id.GetHashCode();
        }
    }
}