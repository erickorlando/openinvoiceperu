#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

using OpenInvoicePeru.Comun.Dto.Contratos;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class GuiaRemision : IDocumentoElectronico
    {
#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string IdDocumento { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string FechaEmision { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string TipoDocumento { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.AllowNull)]
#endif
        public string Glosa { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public Contribuyente Remitente { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public Contribuyente Destinatario { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public Contribuyente Tercero { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.AllowNull)]
#endif
        public DocumentoRelacionado DocumentoRelacionado { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.AllowNull)]
#endif
        public DocumentoRelacionado GuiaBaja { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string CodigoMotivoTraslado { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string DescripcionMotivo { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public bool Transbordo { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public decimal PesoBrutoTotal { get; set; }

        public int NroPallets { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string ModalidadTraslado { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public string FechaInicioTraslado { get; set; }

        public string RucTransportista { get; set; }

        public string RazonSocialTransportista { get; set; }

        public string NroPlacaVehiculo { get; set; }

        public string NroDocumentoConductor { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public Direccion DireccionPartida { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public Direccion DireccionLlegada { get; set; }

        public string NumeroContenedor { get; set; }

        public string CodigoPuerto { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Required = Required.Always)]
#endif
        public List<DetalleGuia> BienesATransportar { get; set; }
    }
}