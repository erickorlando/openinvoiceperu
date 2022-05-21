using System.ComponentModel.DataAnnotations;

namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public class ComprobanteRequest
    {
        public string RucReceptor { get; set; }

        public string RucEmisor { get; set; }

        public string TipoComprobante { get; set; }

        public string NumeroSerie { get; set; }

        public int Numero { get; set; }

        public string FechaEmision { get; set; }

        public decimal Monto { get; set; }
    }
}