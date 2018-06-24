using System;
using System.Collections.Generic;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class TaxTotal
    {
        public PayableAmount TaxAmount { get; set; }

        public TaxSubtotal TaxSubtotal { get; set; }

        public List<TaxSubtotal> TaxSubTotals { get; set; }

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
            TaxAmount = new PayableAmount();
            TaxSubtotal = new TaxSubtotal();
            TaxCategory = new TaxCategory();
            TaxSubTotals = new List<TaxSubtotal>();
        }
    }
}