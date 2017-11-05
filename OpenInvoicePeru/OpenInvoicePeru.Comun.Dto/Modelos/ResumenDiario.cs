using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ResumenDiario : DocumentoResumen
    {
        [JsonProperty(Required = Required.Always)]
        public List<GrupoResumen> Resumenes { get; set; }
    }
}