using System;

namespace OpenInvoicePeru.Firmado.Estructuras
{
    [Serializable]
    public class ExtensionContent
    {
        public AdditionalInformation AdditionalInformation { get; set; }
        
        public ExtensionContent()
        {
            AdditionalInformation = new AdditionalInformation();
        }
    }
}