using System.ComponentModel.DataAnnotations.Schema;

namespace OpenInvoicePeru.Entidades
{
    public class Empresa : IEntity
    {
        public int Id { get; set; }

        public string NroDocumento { get; set; }

        public int IdTipoDocumento { get; set; }

        [ForeignKey(nameof(IdTipoDocumento))]
        public TipoDocumentoContribuyente TipoDocumento { get; set; }

        public string NombreLegal { get; set; }

        public string NombreComercial { get; set; }

        public string Direccion { get; set; }

        public string Urbanizacion { get; set; }

        public string CorreoElectronico { get; set; }

        public int IdUbigeo { get; set; }

        [ForeignKey(nameof(IdUbigeo))]
        public Ubigeo Ubigeo { get; set; }

    }
}