using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenInvoicePeru.FirmadoSunat.Models
{
#if TESTING
    [Serializable]
#endif
    public class Discrepancia
    {
        public string NroReferencia { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
    }
}
