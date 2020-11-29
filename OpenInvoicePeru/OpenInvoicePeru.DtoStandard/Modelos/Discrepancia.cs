using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace OpenInvoicePeru.DtoStandard.Modelos
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