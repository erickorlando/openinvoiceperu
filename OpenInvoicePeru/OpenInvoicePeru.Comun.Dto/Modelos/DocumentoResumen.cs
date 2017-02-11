using OpenInvoicePeru.Comun.Dto.Contratos;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public abstract class DocumentoResumen : IDocumentoElectronico
    {
        public Contribuyente Emisor { get; set; }

        public string IdDocumento { get; set; }

        public string FechaEmision { get; set; }

        public string FechaReferencia { get; set; }
    }
}