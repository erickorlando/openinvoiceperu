using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenInvoicePeru.FirmadoSunat.Models
{
    public class DocumentoBaja : DocumentoResumenDetalle
    {
        public string Correlativo { get; set; }
        public string MotivoBaja { get; set; }
    }
}
