using System;

namespace OpenInvoicePeru.Estructuras
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