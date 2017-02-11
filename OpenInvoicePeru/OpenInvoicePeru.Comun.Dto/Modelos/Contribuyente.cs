using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Contribuyente
    {
        [JsonProperty(Order = 1, Required = Required.Always)]
        public string NroDocumento { get; set; }

        [JsonProperty(Order = 2, Required = Required.Always)]
        public string TipoDocumento { get; set; }

        [JsonProperty(Order = 3, Required = Required.Always)]
        public string NombreLegal { get; set; }

        [JsonProperty(Order = 4)]
        public string NombreComercial { get; set; }

        [JsonProperty(Order = 5)]
        public string Ubigeo { get; set; }

        [JsonProperty(Order = 6)]
        public string Direccion { get; set; }

        [JsonProperty(Order = 7)]
        public string Urbanizacion { get; set; }

        [JsonProperty(Order = 8)]
        public string Departamento { get; set; }

        [JsonProperty(Order = 9)]
        public string Provincia { get; set; }

        [JsonProperty(Order = 10)]
        public string Distrito { get; set; }
    }
}