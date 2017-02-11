using System;
using OpenInvoicePeru.Estructuras.CommonBasicComponents;

namespace OpenInvoicePeru.Estructuras.SunatAggregateComponents
{
    [Serializable]
    public class AdditionalMonetaryTotal
    {
        public string Id { get; set; }

        public PayableAmount PayableAmount { get; set; }

        public PayableAmount ReferenceAmount { get; set; }

        public PayableAmount TotalAmount { get; set; }

        /// <summary>
        /// Para el porcentaje de Detraccion.
        /// </summary>
        public decimal Percent { get; set; }

        public AdditionalMonetaryTotal()
        {
            PayableAmount = new PayableAmount();
            ReferenceAmount = new PayableAmount();
            TotalAmount = new PayableAmount();
        }
    }
}