using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class Discrepancia
    {
        [JsonProperty(Required = Required.Always)]
        public string NroReferencia { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Tipo { get; set; }

        [JsonProperty(Required = Required.Always)]
        [StringLength(500)]
        public string Descripcion { get; set; }
    }
}