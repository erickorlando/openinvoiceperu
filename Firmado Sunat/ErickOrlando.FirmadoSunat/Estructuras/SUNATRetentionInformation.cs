using System;

namespace ErickOrlando.FirmadoSunat.Estructuras
{
    [Serializable]
    public class SUNATRetentionInformation
    {
        public PayableAmount SUNATRetentionAmount { get; set; }
        public string SUNATRetentionDate { get; set; }
        public PayableAmount SUNATNetTotalPaid { get; set; }
        public ExchangeRate ExchangeRate { get; set; }

        public SUNATRetentionInformation()
        {
            SUNATRetentionAmount = new PayableAmount();
            SUNATNetTotalPaid = new PayableAmount();
            ExchangeRate = new ExchangeRate();
        }
    }
}