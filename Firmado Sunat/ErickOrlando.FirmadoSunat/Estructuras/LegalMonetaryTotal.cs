using System;

namespace ErickOrlando.FirmadoSunat.Estructuras
{
    [Serializable]
    public class LegalMonetaryTotal
    {
        public PayableAmount PayableAmount { get; set; }
        public PayableAmount AllowanceTotalAmount { get; set; }
        public PayableAmount ChargeTotalAmount { get; set; }

        public LegalMonetaryTotal()
        {
            PayableAmount = new PayableAmount();
            AllowanceTotalAmount = new PayableAmount();
            ChargeTotalAmount = new PayableAmount();
        }
    }
}