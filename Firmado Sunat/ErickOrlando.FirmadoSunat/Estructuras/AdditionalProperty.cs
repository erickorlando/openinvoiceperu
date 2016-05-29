using System;

namespace ErickOrlando.FirmadoSunat.Estructuras
{
    [Serializable]
    public class AdditionalProperty
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}