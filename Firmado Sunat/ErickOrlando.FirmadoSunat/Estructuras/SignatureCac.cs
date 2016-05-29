using System;

namespace ErickOrlando.FirmadoSunat.Estructuras
{
    [Serializable]
    public class SignatureCac
    {
        public string ID { get; set; }
        public SignatoryParty SignatoryParty { get; set; }
        public DigitalSignatureAttachment DigitalSignatureAttachment { get; set; }

        public SignatureCac()
        {
            SignatoryParty = new SignatoryParty();
            DigitalSignatureAttachment = new DigitalSignatureAttachment();
        }
    }
}