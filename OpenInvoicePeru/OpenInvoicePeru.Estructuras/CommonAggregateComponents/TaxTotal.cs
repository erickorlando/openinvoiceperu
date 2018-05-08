using System;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class TaxTotal
    {
        public PayableAmount TaxableAmount { get; set; }

        public PayableAmount TaxAmount { get; set; }

        public TaxSubtotal TaxSubtotal { get; set; }

        /// <summary>
        /// Tipo de Afectacion del IGV
        /// S = Gravado
        /// E = Exonerado
        /// O = Inafecto
        /// </summary>
        public string TaxCategoryId { get; set; }

        public TaxCategory TaxCategory { get; set; }

        public TaxTotal()
        {
            TaxableAmount = new PayableAmount();
            TaxAmount = new PayableAmount();
            TaxSubtotal = new TaxSubtotal();
            TaxCategoryId = "S";
        }
    }
}