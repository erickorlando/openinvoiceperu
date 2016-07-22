using System;

namespace OpenInvoicePeru.FirmadoSunat.Models
{
    [Serializable]
    public class DocumentoRelacionado
    {
        public string NroDocumento { get; set; }
        public string TipoDocumento { get; set; }
    }
}
