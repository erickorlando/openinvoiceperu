using System;

namespace OpenInvoicePeru.Entidades
{
    public class DocumentoBaja : EntidadBase
    {
        public DateTime FechaEmision { get; set; }
        public DateTime FechaReferencia { get; set; }
        public string IdBaja { get; set; }
        public int IdContribuyente { get; set; }
        public Empresa Contribuyente { get; set; }
    }

    public class DocumentoDetalleBaja : EntidadBase
    {
        public int IdDocumentoBaja { get; set; }
        public int CorrelativoInicio { get; set; }
        public int CorrelativoFin { get; set; }

    }
}