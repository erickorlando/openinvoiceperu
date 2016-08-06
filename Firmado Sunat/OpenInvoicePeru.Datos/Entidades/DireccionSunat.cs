using System.ComponentModel.DataAnnotations;

namespace OpenInvoicePeru.Datos.Entidades
{
    public class DireccionSunat : TipoValorBase
    {
        [Required]
        [StringLength(50)]
        public new string Codigo { get; set; }
    }
}
