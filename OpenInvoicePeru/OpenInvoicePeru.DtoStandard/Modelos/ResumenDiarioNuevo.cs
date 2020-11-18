using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenInvoicePeru.DtoStandard.Modelos
{
    public class ResumenDiarioNuevo : DocumentoResumen
    {
        [JsonProperty(Required = Required.Always)]
        public List<GrupoResumenNuevo> Resumenes { get; set; }
    }
}