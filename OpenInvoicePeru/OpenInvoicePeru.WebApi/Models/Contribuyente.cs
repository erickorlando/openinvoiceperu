namespace OpenInvoicePeru.WebApi.Models
{
    public class Contribuyente : IEntity
    {
        public int Id { get; set; }

        public string NroDocumento { get; set; }

        public int IdTipoDocumento { get; set; }

        public string NombreLegal { get; set; }

        public string NombreComercial { get; set; }

        public string Direccion { get; set; }

        public string Urbanizacion { get; set; }

        public int IdDepartamento { get; set; }

        public int IdProvincia { get; set; }

        public int IdDistrito { get; set; }
    }
}