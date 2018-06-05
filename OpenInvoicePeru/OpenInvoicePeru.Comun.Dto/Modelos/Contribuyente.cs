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

    }
}