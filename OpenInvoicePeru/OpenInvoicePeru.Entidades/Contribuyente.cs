using System.ComponentModel.DataAnnotations.Schema;

namespace OpenInvoicePeru.Entidades
{
    public class Contribuyente : IEntity
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

        public int IdPais { get; set; }

        public int IdDepartamento { get; set; }

        public int IdProvincia { get; set; }

        public int IdDistrito { get; set; }

        [ForeignKey(nameof(IdPais))]
        public Ubigeo Pais { get; set; }

        [ForeignKey(nameof(IdDepartamento))]
        public Ubigeo Departamento { get; set; }

        [ForeignKey(nameof(IdProvincia))]
        public Ubigeo Provincia { get; set; }

        [ForeignKey(nameof(IdDistrito))]
        public Ubigeo Distrito { get; set; }
    }
}