using System;

namespace ErickOrlando.FirmadoSunat.Estructuras
{
    [Serializable]
    public class PayableAmount
    {
        public string currencyID { get; set; }
        public decimal value { get; set; }
    }
}