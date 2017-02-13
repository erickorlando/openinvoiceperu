using System;
using System.Collections.Generic;

namespace OpenInvoicePeru.Estructuras.CommonAggregateComponents
{
    [Serializable]
    public class TransportHandlingUnit
    {
        public string Id { get; set; }

        public List<TransportEquipment> TransportEquipments { get; set; }

        public TransportHandlingUnit()
        {
            TransportEquipments = new List<TransportEquipment>();
        }
    }
}