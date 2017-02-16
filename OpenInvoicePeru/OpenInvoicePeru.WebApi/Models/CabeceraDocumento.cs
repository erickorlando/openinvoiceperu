namespace OpenInvoicePeru.WebApi.Models
{
    public class CabeceraDocumento : IEntity
    {
        public int Id { get; set; }

        public string IdDocumento { get; set; }

        public int IdTipoDocumento { get; set; }

        public int IdEmisor { get; set; }

        public int IdReceptor { get; set; }

        public int IdMoneda { get; set; }

        public int IdTipoOperacion { get; set; }

        public decimal Gravadas { get; set; }

        public decimal Gratuitas { get; set; }

        public decimal Inafectas { get; set; }

        public decimal Exoneradas { get; set; }

        public decimal DescuentoGlobal { get; set; }

        public decimal TotalVenta { get; set; }

        public decimal TotalIgv { get; set; }

        public decimal TotalIsc { get; set; }

        public decimal TotalOtrosTributos { get; set; }

        public string MontoEnLetras { get; set; }

        public string PlacaVehiculo { get; set; }

        public decimal MontoPercepcion { get; set; }

        public decimal MontoDetraccion { get; set; }

        public int? IdDocumentoAnticipo { get; set; }

        public int? IdGuiaTransportista { get; set; }

    }
}