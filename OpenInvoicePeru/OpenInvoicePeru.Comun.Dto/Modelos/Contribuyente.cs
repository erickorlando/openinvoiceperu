#if !SILVERLIGHT
using Newtonsoft.Json;
#endif

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Contribuyente
    {
#if !SILVERLIGHT
        [JsonProperty(Order = 1, Required = Required.Always)]
#endif
        public string NroDocumento { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Order = 2, Required = Required.Always)]
#endif
        public string TipoDocumento { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Order = 3, Required = Required.Always)]
#endif
        public string NombreLegal { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 4)]
#endif
        public string NombreComercial { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Order = 5)]
#endif
        public string Ubigeo { get; set; }
#if !SILVERLIGHT
        [JsonProperty(Order = 6)]
#endif
        public string Direccion { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 7)]
#endif
        public string Urbanizacion { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 8)]
#endif
        public string Departamento { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 9)]
#endif
        public string Provincia { get; set; }

#if !SILVERLIGHT
        [JsonProperty(Order = 10)]
#endif
        public string Distrito { get; set; }
    }
}