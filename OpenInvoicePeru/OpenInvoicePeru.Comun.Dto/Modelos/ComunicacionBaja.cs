using System.Collections.Generic;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class ComunicacionBaja : DocumentoResumen
    {
        public List<DocumentoBaja> Bajas { get; set; }
    }
}
