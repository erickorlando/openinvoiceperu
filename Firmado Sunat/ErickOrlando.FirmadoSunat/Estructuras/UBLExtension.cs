using System;

namespace OpenInvoicePeru.FirmadoSunat.Estructuras
{
    [Serializable]
    public class UBLExtension
    {
        public ExtensionContent ExtensionContent { get; set; }

        public UBLExtension()
        {
            ExtensionContent = new ExtensionContent();
        }
    }
}