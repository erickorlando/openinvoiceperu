using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenInvoicePeru.FirmadoSunat.Models
{
    public class ConsultaTicketRequest : EnvioDocumentoComun
    {
        public string NroTicket { get; set; }
    }
}
