using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Negocio : Contribuyente
    {
        [JsonProperty(Order = 6)]
        public string Ubigeo { get; set; }

        [JsonProperty(Order = 7)]
        public string Direccion { get; set; }

        [JsonProperty(Order = 8)]
        public string Urbanizacion { get; set; }

        [JsonProperty(Order = 9)]
        public string Departamento { get; set; }

        [JsonProperty(Order = 10)]
        public string Provincia { get; set; }

        [JsonProperty(Order = 11)]
        public string Distrito { get; set; }
    }
}