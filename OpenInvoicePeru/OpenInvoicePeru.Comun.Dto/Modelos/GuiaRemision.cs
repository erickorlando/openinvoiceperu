using OpenInvoicePeru.Comun.Dto.Contratos;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class GuiaRemision : IDocumentoElectronico
    {
        public string IdDocumento { get; set; }

        public string FechaEmision { get; set; }

        public string TipoDocumento { get; set; }

        public string Glosa { get; set; }

        public Contribuyente Remitente { get; set; }

        public Contribuyente Destinatario { get; set; }

        public Contribuyente Tercero { get; set; }

        public DocumentoRelacionado DocumentoRelacionado { get; set; }

        public DocumentoRelacionado GuiaBaja { get; set; }

        public string CodigoMotivoTraslado { get; set; }

        public string DescripcionMotivo { get; set; }

        public bool Transbordo { get; set; }

        public decimal PesoBrutoTotal { get; set; }

        public int NroPallets { get; set; }

        public string ModalidadTraslado { get; set; }

        public string FechaInicioTraslado { get; set; }

        public string RucTransportista { get; set; }

        public string RazonSocialTransportista { get; set; }

        public string NroPlacaVehiculo { get; set; }

        public string NroDocumentoConductor { get; set; }

        public Direccion DireccionPartida { get; set; }

        public Direccion DireccionLlegada { get; set; }

        public string NumeroContenedor { get; set; }

        public string CodigoPuerto { get; set; }

        public List<DetalleGuia> BienesATransportar { get; set; }
    }
}