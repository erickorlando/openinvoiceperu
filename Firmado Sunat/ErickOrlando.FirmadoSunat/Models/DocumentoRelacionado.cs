using System;

namespace OpenInvoicePeru.FirmadoSunat.Models
{
#if TESTING
    [Serializable]
#endif
    public class DocumentoRelacionado
    {
        public string NroDocumento { get; set; }
        public string TipoDocumento { get; set; }
    }
}
