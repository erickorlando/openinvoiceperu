using System;
using System.Linq;
using System.Windows.Forms;
using OpenInvoicePeru.Datos;
using OpenInvoicePeru.Firmado.Models;

namespace OpenInvoicePeru.WinApp
{
    public partial class FrmDatosAdicionales : Form
    {
        private readonly DatoAdicional _dato;

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
            Load += (s, e) =>
            {
                using (var ctx = new OpenInvoicePeruDb())
                {
                    tipoDatoAdicionalBindingSource.DataSource = ctx.TipoDatoAdicionales.ToList();
                    tipoDatoAdicionalBindingSource.ResetBindings(false);
                }
            };
            toolCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        private void toolOk_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                datoAdicionalBindingSource.EndEdit();
                datoAdicionalBindingSource.RaiseListChangedEvents = false;
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
