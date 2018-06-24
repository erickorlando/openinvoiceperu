using Newtonsoft.Json;

using OpenInvoicePeru.Comun.Dto.Contratos;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class GuiaRemision : IDocumentoElectronico
    {
        [JsonProperty(Required = Required.Always)]
        public string IdDocumento { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string FechaEmision { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoDocumento { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string Glosa { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Contribuyente Remitente { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Contribuyente Destinatario { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Contribuyente Tercero { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public DocumentoRelacionado DocumentoRelacionado { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public DocumentoRelacionado GuiaBaja { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string CodigoMotivoTraslado { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string DescripcionMotivo { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool Transbordo { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal PesoBrutoTotal { get; set; }

        public int NroPallets { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string ModalidadTraslado { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string FechaInicioTraslado { get; set; }

        public string RucTransportista { get; set; }

        public string RazonSocialTransportista { get; set; }

        public string NroPlacaVehiculo { get; set; }

        public string NroDocumentoConductor { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Direccion DireccionPartida { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Direccion DireccionLlegada { get; set; }

        public string NumeroContenedor { get; set; }

        public string CodigoPuerto { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<DetalleGuia> BienesATransportar { get; set; }

        public string ShipmentId { get; set; }
    }
}