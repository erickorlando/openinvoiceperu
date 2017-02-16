namespace OpenInvoicePeru.WebApi.Models
{
    public class TipoDocumento : IEntity
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }
    }
}