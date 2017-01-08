using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ResumenDiarioNuevo : DocumentoResumen
    {
        public List<GrupoResumenNuevo> Resumenes { get; set; }
    }
}