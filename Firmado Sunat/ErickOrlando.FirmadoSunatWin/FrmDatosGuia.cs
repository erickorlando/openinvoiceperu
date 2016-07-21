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
    public partial class FrmDatosGuia : Form
    {
        private DatosGuia _datosGuia;

        public FrmDatosGuia()
        {
            InitializeComponent();
        }

        public FrmDatosGuia(DatosGuia datosGuia)
        {
            InitializeComponent();
            _datosGuia = datosGuia;

            datosGuiaBindingSource.DataSource = _datosGuia;
            datosGuiaBindingSource.ResetBindings(false);

            toolOk.Click += (s, e) =>
            {
                datosGuiaBindingSource.EndEdit();
                _datosGuia.TipoDocTransportista = tipoDocTransportistaComboBox.Text;
                _datosGuia.ModoTransporte = modoTransporteComboBox.Text;
                _datosGuia.UnidadMedida = unidadMedidaComboBox.Text;
                
                DialogResult = DialogResult.OK;
            };

            toolCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }
    }
}
