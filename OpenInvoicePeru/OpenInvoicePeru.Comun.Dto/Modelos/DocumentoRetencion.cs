using OpenInvoicePeru.Comun.Dto.Contratos;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoRetencion : IDocumentoElectronico
    {
        public Contribuyente Emisor { get; set; }

        public Contribuyente Receptor { get; set; }

        public string IdDocumento { get; set; }

        public string FechaEmision { get; set; }

        public string Moneda { get; set; }

        public string RegimenRetencion { get; set; }

        public decimal TasaRetencion { get; set; }

        public string Observaciones { get; set; }

        public decimal ImporteTotalRetenido { get; set; }

        public decimal ImporteTotalPagado { get; set; }

        public List<ItemRetencion> DocumentosRelacionados { get; set; }
    }
}