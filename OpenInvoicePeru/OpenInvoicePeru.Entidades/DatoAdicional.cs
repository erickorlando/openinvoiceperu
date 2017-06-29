using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenInvoicePeru.Entidades
{
    public class DatoAdicional : EntidadBase
    {
        public int IdCabeceraDocumento { get; set; }

        [ForeignKey(nameof(IdCabeceraDocumento))]
        public CabeceraDocumento CabeceraDocumento { get; set; }

        public int IdTipoDatoAdicional { get; set; }

        [ForeignKey(nameof(IdTipoDatoAdicional))]
        public TipoDatoAdicional TipoDatoAdicional { get; set; }

        [Required]
        [MaxLength(250)]
        public string Contenido { get; set; }
    }
}