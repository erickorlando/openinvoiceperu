using System;
using System.Windows.Forms;
using OpenInvoicePeru.FirmadoSunat.Models;

namespace OpenInvoicePeru.FirmadoSunatWin
{
    public partial class FrmDetalleDocumento : Form
    {
        private readonly DetalleDocumento _detalle;
        private readonly DocumentoElectronico _documento;

        public FrmDetalleDocumento()
        {
            InitializeComponent();
        }

        public FrmDetalleDocumento(DetalleDocumento detalle, DocumentoElectronico documento)
        {
            InitializeComponent();
            _detalle = detalle;
            _documento = documento;

            detalleDocumentoBindingSource.DataSource = detalle;
            detalleDocumentoBindingSource.ResetBindings(false);

            tipoImpuestoComboBox.SelectedIndex = 0;
            tipoPrecioComboBox.SelectedIndex = 0;
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void toolOk_Click(object sender, EventArgs e)
        {
            tipoPrecioComboBox.Focus();

            _detalle.TipoPrecio = tipoPrecioComboBox.Text;
            _detalle.TipoImpuesto = tipoImpuestoComboBox.Text;

            // Evaluamos el tipo de Impuesto.
            if (!_detalle.TipoImpuesto.Contains("Gravado"))
            {
                _detalle.Suma = _detalle.PrecioUnitario * _detalle.Cantidad;
                _detalle.TotalVenta = _detalle.Suma;
            }
            else
            {
                if (_detalle.OtroImpuesto > 0)
                    _detalle.TotalVenta = _detalle.TotalVenta + _detalle.OtroImpuesto;
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCalcIgv_Click(object sender, EventArgs e)
        {
            _detalle.Suma = _detalle.PrecioUnitario * _detalle.Cantidad;
            _detalle.Impuesto = _detalle.Suma * _documento.CalculoIgv;
            _detalle.TotalVenta = _detalle.Suma + _detalle.Impuesto;

            detalleDocumentoBindingSource.ResetBindings(false);
        }

        private void btnCalcIsc_Click(object sender, EventArgs e)
        {
            _detalle.Suma = _detalle.PrecioUnitario * _detalle.Cantidad;
            _detalle.ImpuestoSelectivo = _detalle.Suma * _documento.CalculoIsc;
            // Recalculamos el IGV.
            _detalle.Impuesto = (_detalle.Suma + _detalle.ImpuestoSelectivo) * _documento.CalculoIgv;
            _detalle.TotalVenta = _detalle.Suma + _detalle.Impuesto;

            detalleDocumentoBindingSource.ResetBindings(false);
        }
    }
}
