using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class DatosGuia
    {
        [JsonProperty(Required = Required.Always)]
        public Contribuyente DireccionDestino { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Contribuyente DireccionOrigen { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string RucTransportista { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string TipoDocTransportista { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string NombreTransportista { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string NroLicenciaConducir { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string PlacaVehiculo { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string CodigoAutorizacion { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string MarcaVehiculo { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string ModoTransporte { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string UnidadMedida { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal PesoBruto { get; set; }

        public DatosGuia()
        {
            DireccionDestino = new Contribuyente();
            DireccionOrigen = new Contribuyente();
        }
    }
}