using System.ComponentModel.DataAnnotations;

namespace OpenInvoicePeru.Entidades
{
    public class Ubigeo : EntidadBase
    {
        [Required]
        [MaxLength(6)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descripcion { get; set; }

    }
}