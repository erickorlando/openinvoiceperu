using System.Collections.Generic;

namespace OpenInvoicePeru.FirmadoSunat.Models
{
    public class ResumenDiario : DocumentoResumen
    {
        public List<GrupoResumen> Resumenes { get; set; }
    }
}
