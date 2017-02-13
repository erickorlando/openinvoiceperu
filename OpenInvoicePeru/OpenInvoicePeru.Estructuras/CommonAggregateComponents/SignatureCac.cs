using System;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class SignatureCac
    {
        public string Id { get; set; }

        public SignatoryParty SignatoryParty { get; set; }

        public DigitalSignatureAttachment DigitalSignatureAttachment { get; set; }

        public SignatureCac()
        {
            SignatoryParty = new SignatoryParty();
            DigitalSignatureAttachment = new DigitalSignatureAttachment();
        }
    }
}