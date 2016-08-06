using System.Collections.Generic;

namespace OpenInvoicePeru.FirmadoSunat.Models
{
    public class ComunicacionBaja : DocumentoResumen
    {
        public List<DocumentoBaja> Bajas { get; set; }
    }
}
