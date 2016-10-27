using System.Collections.Generic;

namespace OpenInvoicePeru.Firmado.Models
{
    public class ResumenDiario : DocumentoResumen
    {
        public List<GrupoResumen> Resumenes { get; set; }
    }
}
