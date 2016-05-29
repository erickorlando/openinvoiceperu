using System;

namespace ErickOrlando.FirmadoSunat.Estructuras
{
    [Serializable]
    public class UBLExtensions
    {
        public UBLExtension Extension1 { get; set; }
        public UBLExtension Extension2 { get; set; }

        public UBLExtensions()
        {
            Extension1 = new UBLExtension();
            Extension2 = new UBLExtension();
        }
    }
}