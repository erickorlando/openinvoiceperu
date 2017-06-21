using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenInvoicePeru.Entidades
{
    public class DiscrepanciaDocumento : EntidadBase
    {
        public int IdCabeceraDocumento { get; set; }

        [ForeignKey(nameof(IdCabeceraDocumento))]
        public CabeceraDocumento CabeceraDocumento { get; set; }

        [Required]
        [MaxLength(15)]
        public string NroReferencia { get; set; }

        public int IdTipoDiscrepancia { get; set; }

        [ForeignKey(nameof(IdTipoDiscrepancia))]
        public TipoDiscrepancia TipoDiscrepancia { get; set; }
    }
}