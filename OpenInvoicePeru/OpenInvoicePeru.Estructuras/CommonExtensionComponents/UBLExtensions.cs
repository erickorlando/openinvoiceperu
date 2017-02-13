using System;

namespace OpenInvoicePeru.Estructuras.CommonExtensionComponents
{
    [Serializable]
    public class UblExtensions
    {
        public UblExtension Extension1 { get; set; }

        public UblExtension Extension2 { get; set; }

        public UblExtensions()
        {
            Extension1 = new UblExtension();
            Extension2 = new UblExtension();
        }
    }
}