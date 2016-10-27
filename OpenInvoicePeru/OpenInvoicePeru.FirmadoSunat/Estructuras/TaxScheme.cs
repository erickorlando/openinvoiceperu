using System;

namespace OpenInvoicePeru.Firmado.Estructuras
{
    [Serializable]
    public class TaxScheme
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string TaxTypeCode { get; set; }
    }
}