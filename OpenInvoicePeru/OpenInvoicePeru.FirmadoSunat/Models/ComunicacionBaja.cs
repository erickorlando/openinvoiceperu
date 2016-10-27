using System.Collections.Generic;

namespace OpenInvoicePeru.Firmado.Models
{
    public class ComunicacionBaja : DocumentoResumen
    {
        public List<DocumentoBaja> Bajas { get; set; }
    }
}
