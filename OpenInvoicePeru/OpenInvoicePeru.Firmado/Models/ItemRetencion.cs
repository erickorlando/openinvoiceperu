namespace OpenInvoicePeru.Firmado.Models
{
    public class ItemRetencion : DocumentoRelacionado
    {
        public string FechaEmision { get; set; }
        public decimal ImporteTotal { get; set; }

        public string FechaPago { get; set; }
        public int NumeroPago { get; set; }
        public decimal ImporteSinRetencion { get; set; }
        public string MonedaPago { get; set; }

        public decimal ImporteRetenido { get; set; }
        public string FechaRetencion { get; set; }
        public decimal ImporteTotalNeto { get; set; }

        public decimal TipoCambio { get; set; }
        public string FechaTipoCambio { get; set; }
    }
}