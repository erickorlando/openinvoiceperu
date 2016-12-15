using System;
using System.Linq;
using System.Windows.Forms;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Datos;

namespace OpenInvoicePeru.WinApp
{
    public partial class FrmDetalleDocumento : PlantillaBase
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

            Load += (s, e) =>
            {
                using (var ctx = new OpenInvoicePeruDb())
                {
                    tipoImpuestoBindingSource.DataSource = ctx.TipoImpuestos.ToList();
                    tipoImpuestoBindingSource.ResetBindings(false);

                    tipoPrecioBindingSource.DataSource = ctx.TipoPrecios.ToList();
                    tipoPrecioBindingSource.ResetBindings(false);
                }
            };
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void toolOk_Click(object sender, EventArgs e)
        {
            tipoPrecioComboBox.Focus();
            _detalle.UnidadMedida = unidadMedidaComboBox.Text;

            // Evaluamos el tipo de Impuesto.
            if (!_detalle.TipoImpuesto.StartsWith("1"))
            {
                _detalle.Suma = _detalle.PrecioUnitario * _detalle.Cantidad;
                _detalle.TotalVenta = _detalle.Suma - _detalle.Descuento;
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
            _detalle.TotalVenta = _detalle.Suma - _detalle.Descuento;

            detalleDocumentoBindingSource.ResetBindings(false);
        }

        private void btnCalcIsc_Click(object sender, EventArgs e)
        {
            _detalle.Suma = _detalle.PrecioUnitario * _detalle.Cantidad;
            _detalle.ImpuestoSelectivo = _detalle.Suma * _documento.CalculoIsc;

            detalleDocumentoBindingSource.ResetBindings(false);
        }
    }
}
