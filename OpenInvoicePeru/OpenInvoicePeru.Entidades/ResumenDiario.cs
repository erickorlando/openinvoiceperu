using System;

namespace OpenInvoicePeru.Entidades
{
    public class ResumenDiario : EntidadBase
    {
        public DateTime FechaEmision { get; set; }
        public DateTime FechaReferencia { get; set; }
        public string IdResumen { get; set; }
        public int IdContribuyente { get; set; }
        public Empresa Contribuyente { get; set; }

    }
}