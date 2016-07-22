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
    public partial class FrmDiscrepancia : Form
    {
        private readonly Discrepancia _discrepancia;

        public FrmDiscrepancia()
        {
            InitializeComponent();
        }

        public FrmDiscrepancia(Discrepancia discrepancia)
        {
            InitializeComponent();
            _discrepancia = discrepancia;
            discrepanciaBindingSource.DataSource = _discrepancia;
            discrepanciaBindingSource.ResetBindings(false);

            toolOk.Click += (s, e) =>
            {
                discrepanciaBindingSource.EndEdit();
                _discrepancia.Tipo = tipoComboBox.Text;

                DialogResult = DialogResult.OK;
            };

            toolCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }
    }
}
