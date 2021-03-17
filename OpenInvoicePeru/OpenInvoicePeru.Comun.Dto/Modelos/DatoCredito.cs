using System;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DatoCredito
    {
        public int NroCuota { get; set; }
        public decimal MontoCuota { get; set; }
        public string FechaCredito { get; set; }

        public DatoCredito()
        {
            FechaCredito = DateTime.Today.ToString("yyyy-MM-dd");
        }
    }
}