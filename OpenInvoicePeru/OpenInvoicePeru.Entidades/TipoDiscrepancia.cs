using System.ComponentModel.DataAnnotations.Schema;

namespace OpenInvoicePeru.Entidades
{
    public class TipoDiscrepancia : TipoValorBase
    {
        public int IdTipoDocumento { get; set; }

        [ForeignKey(nameof(IdTipoDocumento))]
        public TipoDocumento TipoDocumento { get; set; }
    }
}
