using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenInvoicePeru.FirmadoSunat.Models
{
    public class FirmadoResponse
    {
        public string TramaXmlFirmado { get; set; }
        public string ResumenFirma { get; set; }
        public string ValorFirma { get; set; }
    }
}
