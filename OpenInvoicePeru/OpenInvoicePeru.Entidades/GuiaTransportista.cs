namespace OpenInvoicePeru.Entidades
{
    public class GuiaTransportista : EntidadBase
    {
        public int IdModoTransporte { get; set; }

        public ModalidadTransporte ModalidadTransporte { get; set; }

        public int IdTipoDocTransportista { get; set; }

        public TipoDocumentoContribuyente TipoDocTransportista { get; set; }

        public int IdUnidadMedida { get; set; }

        public UnidadMedida UnidadMedida { get; set; }

        public string CodigoAutorizacion { get; set; }

        public string MarcaVehiculo { get; set; }

        public string NombreTransportista { get; set; }

        public string NroLicencia { get; set; }

        public string RucTransportista { get; set; }

        public decimal PesoBruto { get; set; }
    }
}