using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenInvoicePeru.FirmadoSunat.Models
{
    public abstract class DocumentoResumenDetalle
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string Serie { get; set; }
    }
}
