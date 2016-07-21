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
    public partial class FrmDatosAdicionales : Form
    {
        private DatoAdicional _dato;

        public FrmDatosAdicionales()
        {
            InitializeComponent();
        }

        public FrmDatosAdicionales(DatoAdicional dato)
        {
            InitializeComponent();
            _dato = dato;
            datoAdicionalBindingSource.DataSource = _dato;
            datoAdicionalBindingSource.ResetBindings(false);
            Load += (s,e) => codigoComboBox.SelectedIndex = 0;
        }

        private void toolOk_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                datoAdicionalBindingSource.EndEdit();
                datoAdicionalBindingSource.RaiseListChangedEvents = false;
                _dato.Codigo = codigoComboBox.Text;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                datoAdicionalBindingSource.RaiseListChangedEvents = true;
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
