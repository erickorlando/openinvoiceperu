using System;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class TaxCategory
    {
        public decimal Percent { get; set; }

        public string TaxExemptionReasonCode { get; set; }

        public string TierRange { get; set; }

        public TaxScheme TaxScheme { get; set; }

        public PayableAmount PerUnitAmount { get; set; }

        /// <summary>
        /// Tipo de Afectacion del IGV
        /// S = Gravado
        /// E = Exonerado
        /// O = Inafecto
        /// </summary>
        public string Id { get; set; }

        public TaxCategory()
        {
            TaxScheme = new TaxScheme();
            PerUnitAmount = new PayableAmount();
            Percent = 18;
        }
    }
}