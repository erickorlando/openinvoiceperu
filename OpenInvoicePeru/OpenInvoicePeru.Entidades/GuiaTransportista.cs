using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenInvoicePeru.Entidades
{
    public class GuiaTransportista : EntidadBase
    {
        public int IdModoTransporte { get; set; }

        [ForeignKey(nameof(IdModoTransporte))]
        public ModoTransporte ModoTransporte { get; set; }

        public int IdTipoDocTransportista { get; set; }

        [ForeignKey(nameof(IdTipoDocTransportista))]
        public TipoDocumentoContribuyente TipoDocTransportista { get; set; }

        public int IdUnidadMedida { get; set; }

        [ForeignKey(nameof(IdUnidadMedida))]
        public UnidadMedida UnidadMedida { get; set; }

        [Required]
        [StringLength(10)]
        public string CodigoAutorizacion { get; set; }

        [Required]
        [StringLength(50)]
        public string MarcaVehiculo { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreTransportista { get; set; }

        [Required]
        [StringLength(10)]
        public string NroLicencia { get; set; }

        [Required]
        [StringLength(11)]
        public string RucTransportista { get; set; }

        public decimal PesoBruto { get; set; }

        public ICollection<CabeceraDocumento> Documentos { get; set; }
    }
}