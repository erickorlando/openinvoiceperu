#if !SILVERLIGHT
using Newtonsoft.Json;
#endif
using OpenInvoicePeru.Comun.Dto.Contratos;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DocumentoPercepcion : DocumentoSunatBase, IDocumentoElectronico
    {
#if !SILVERLIGHT
        [JsonProperty(Order = 7, Required = Required.Always)]
#endif
        public string RegimenPercepcion { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 8, Required = Required.Always)]
#endif
        public decimal TasaPercepcion { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Order = 9, Required = Required.Always)]
#endif
        public decimal ImporteTotalPercibido { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Order = 10, Required = Required.Always)]
#endif
        public decimal ImporteTotalCobrado { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Order = 11, Required = Required.Always)]
#endif
        public List<ItemPercepcion> DocumentosRelacionados { get; set; }
    }
}