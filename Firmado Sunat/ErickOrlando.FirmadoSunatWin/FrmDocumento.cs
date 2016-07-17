using System;
using System.Windows.Forms;
using OpenInvoicePeru.FirmadoSunat.Models;

namespace OpenInvoicePeru.FirmadoSunatWin
{
    public partial class FrmDocumento : Form
    {
        private DocumentoElectronico _documento;

        public FrmDocumento()
        {
            InitializeComponent();
            _documento = new DocumentoElectronico
            {
                FechaEmision = DateTime.Today.ToShortDateString()
            };

            documentoElectronicoBindingSource.DataSource = _documento;
            documentoElectronicoBindingSource.ResetBindings(false);

            emisorBindingSource.DataSource = _documento.Emisor;
            emisorBindingSource.ResetBindings(false);

            receptorBindingSource.DataSource = _documento.Receptor;
            receptorBindingSource.ResetBindings(false);

            cboTipoDoc.SelectedIndex = 0;
            cboMoneda.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            tipoOperacionComboBox.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmDetalleDocumento(new DetalleDocumento()))
            {
                frm.ShowDialog(this);
            }
        }
    }
}
