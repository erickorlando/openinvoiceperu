using System.ComponentModel.DataAnnotations;

namespace OpenInvoicePeru.Entidades
{
    public class TipoValorBase : EntidadBase
    {
        [Required]
        [StringLength(5)]
        public string Codigo { get; set; }
        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; }

        public string DescripcionCompleta => $"{Codigo}: {Descripcion}";
    }
}
