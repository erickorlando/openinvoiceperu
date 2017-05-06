using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenInvoicePeru.Entidades
{
    public class DocumentoAnticipo : EntidadBase
    {
        [Required]
        public string NroDocAnticipo { get; set; }

        public int IdTipoDocumento { get; set; }

        [ForeignKey(nameof(IdTipoDocumento))]
        public TipoDocumento TipoDocumento { get; set; }

        public int IdMoneda { get; set; }

        [ForeignKey(nameof(IdMoneda))]
        public Moneda Moneda { get; set; }

        public decimal MontoAnticipo { get; set; }
    }
}