using System.ComponentModel.DataAnnotations;

namespace OpenInvoicePeru.Entidades
{
    public class TipoDiscrepancia : TipoValorBase
    {
        [Required]
        [StringLength(2)]
        public string DocumentoAplicado { get; set; }
    }
}
