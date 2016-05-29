using System;

namespace ErickOrlando.FirmadoSunat.Estructuras
{
    [Serializable]
    public class InvoiceDocumentReference : IEquatable<InvoiceDocumentReference>
    {
        public string ID { get; set; }
        public string DocumentTypeCode { get; set; }

        public InvoiceDocumentReference()
        {
            ID = string.Empty;
        }
        public bool Equals(InvoiceDocumentReference other)
        {
            if (string.IsNullOrEmpty(ID))
                return false;
            return ID.Equals(other.ID);
        }

        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(ID))
                return base.GetHashCode();

            return ID.GetHashCode();
        }
    }
}