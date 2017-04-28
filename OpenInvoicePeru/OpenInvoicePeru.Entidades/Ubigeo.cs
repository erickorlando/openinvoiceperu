using System.ComponentModel.DataAnnotations;

namespace OpenInvoicePeru.Entidades
{
    public class Ubigeo : EntidadBase
    {
        [Required]
        [MaxLength(2)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(200)]
        public string Descripcion { get; set; }

        public int Nivel { get; set; }

        public int? IdParent { get; set; }

        public virtual Ubigeo UbigeoPadre { get; set; }
    }
}