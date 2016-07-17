using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenInvoicePeru.FirmadoSunat.Models;

namespace OpenInvoicePeru.FirmadoSunatWin
{
    public partial class FrmDetalleDocumento : Form
    {
        private DetalleDocumento _detalle;

        public FrmDetalleDocumento()
        {
            InitializeComponent();
        }

        public FrmDetalleDocumento(DetalleDocumento detalle)
        {
            InitializeComponent();
            _detalle = detalle;
            detalleDocumentoBindingSource.DataSource = detalle;
            detalleDocumentoBindingSource.ResetBindings(false);
        }
    }
}
