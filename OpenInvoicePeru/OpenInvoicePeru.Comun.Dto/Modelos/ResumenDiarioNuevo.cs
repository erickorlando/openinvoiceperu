using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ResumenDiarioNuevo : DocumentoResumen
    {
        [JsonProperty(Required = Required.Always)]
        public List<GrupoResumenNuevo> Resumenes { get; set; }
    }
}