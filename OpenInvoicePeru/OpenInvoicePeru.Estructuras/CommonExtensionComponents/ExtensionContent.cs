using System;
using OpenInvoicePeru.Estructuras.SunatAggregateComponents;

namespace OpenInvoicePeru.Estructuras.CommonExtensionComponents
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