using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ComunicacionBaja : DocumentoResumen
    {
        [JsonProperty(Required = Required.Always)]
        public List<DocumentoBaja> Bajas { get; set; }
    }
}