using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using OpenInvoicePeru.FirmadoSunat.Models;

namespace OpenInvoicePeru.FirmadoSunatWin
{
    public partial class FrmDocumento : Form
    {
        private readonly DocumentoElectronico _documento;

        public string RutaArchivo { get; set; }
        public string IdDocumento { get; set; }
        public FrmDocumento()
        {
            InitializeComponent();
            _documento = new DocumentoElectronico
            {
                FechaEmision = DateTime.Today.ToShortDateString(),
                IdDocumento = "FF11-00001"
            };
            Inicializar();
        }

        public FrmDocumento(DocumentoElectronico documento)
        {
            InitializeComponent();
            _documento = documento;
            Inicializar();
        }
        private void Inicializar()
        {
            documentoElectronicoBindingSource.DataSource = _documento;
            documentoElectronicoBindingSource.ResetBindings(false);

            emisorBindingSource.DataSource = _documento.Emisor;
            emisorBindingSource.ResetBindings(false);

            receptorBindingSource.DataSource = _documento.Receptor;
            receptorBindingSource.ResetBindings(false);

            cboTipoDoc.SelectedIndex = 0;
            cboMoneda.SelectedIndex = 0;
            cboTipoDocRec.SelectedIndex = 3;
            tipoOperacionComboBox.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            switch (tbPaginas.SelectedIndex)
            {
                case 0:
                    var detalle = new DetalleDocumento();

                    using (var frm = new FrmDetalleDocumento(detalle, _documento))
                    {
                        if (frm.ShowDialog(this) != DialogResult.OK) return;

                        _documento.Items.Add(detalle);

                        CalcularTotales();
                    }
                    break;
                case 1:
                    var datoAdicional = new DatoAdicional();
                    using (var frm = new FrmDatosAdicionales(datoAdicional))
                    {
                        if (frm.ShowDialog(this) != DialogResult.OK) return;

                        _documento.DatoAdicionales.Add(datoAdicional);
                        documentoElectronicoBindingSource.ResetBindings(false);
                    }
                    break;

            }

        }

        private void CalcularTotales()
        {
            // Realizamos los cálculos respectivos.
            _documento.TotalIgv = _documento.Items.Sum(d => d.Impuesto);
            _documento.TotalIsc = _documento.Items.Sum(d => d.ImpuestoSelectivo);
            _documento.TotalOtrosTributos = _documento.Items.Sum(d => d.OtroImpuesto);

            _documento.Gravadas = _documento.Items
                .Where(d => d.TipoImpuesto.Contains("Gravado"))
                .Sum(d => d.Suma);

            _documento.Exoneradas = _documento.Items
                .Where(d => d.TipoImpuesto.Contains("20"))
                .Sum(d => d.Suma);

            _documento.Inafectas = _documento.Items
                .Where(d => d.TipoImpuesto.Contains("Inafecto") || d.TipoImpuesto.Contains("40"))
                .Sum(d => d.Suma);

            _documento.Gratuitas = _documento.Items
                .Where(d => d.TipoImpuesto.Contains("21"))
                .Sum(d => d.Suma);

            // Cuando existe ISC se debe recalcular el IGV.
            if (_documento.TotalIsc > 0)
            {
                _documento.TotalIgv = (_documento.Gravadas + _documento.TotalIsc) * _documento.CalculoIgv;
                // Se recalcula nuevamente el Total de Venta.
            }

            _documento.TotalVenta = _documento.Gravadas + _documento.Exoneradas + _documento.Inafectas +
                                    _documento.TotalIgv + _documento.TotalIsc + _documento.TotalOtrosTributos;

            documentoElectronicoBindingSource.ResetBindings(false);
        }

        private void btnDuplicar_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var registro = detallesBindingSource.Current as DetalleDocumento;
                if (registro == null) return;

                var copia = registro.Clone() as DetalleDocumento;
                if (copia == null) return;

                copia.Id = copia.Id + 1;
                _documento.Items.Add(copia);

                CalcularTotales();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var registro = detallesBindingSource.Current as DetalleDocumento;
                if (registro == null) return;

                _documento.Items.Remove(registro);

                CalcularTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void toolGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                documentoElectronicoBindingSource.EndEdit();
                totalVentaTextBox.Focus();

                var proxy = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlOpenInvoicePeruApi"]) };

                var doc = (DocumentoElectronico)_documento.Clone();

                doc.Emisor = emisorBindingSource.Current as Contribuyente;
                if (doc.Emisor != null) doc.Emisor.TipoDocumento = "6";

                doc.Receptor = receptorBindingSource.Current as Contribuyente;
                if (doc.Receptor != null) doc.Receptor.TipoDocumento = cboTipoDocRec.Text.Substring(0, 1);

                doc.Moneda = cboMoneda.Text;
                doc.TipoDocumento = cboTipoDoc.Text.Substring(0, 2);
                doc.TipoOperacion = tipoOperacionComboBox.Text.Substring(0, 2);

                foreach (var item in doc.Items)
                {
                    item.TipoImpuesto = item.TipoImpuesto.Substring(0, 2);
                    item.TipoPrecio = item.TipoPrecio.Substring(0, 2);
                }

                foreach (var adicional in doc.DatoAdicionales)
                {
                    adicional.Codigo = adicional.Codigo.Substring(0, 4);
                }

                if (doc.DatosGuiaTransportista != null)
                {
                    doc.DatosGuiaTransportista.ModoTransporte = doc.DatosGuiaTransportista.ModoTransporte.Substring(0, 2);
                    doc.DatosGuiaTransportista.TipoDocTransportista =
                        doc.DatosGuiaTransportista.TipoDocTransportista.Substring(0, 1);
                }

                if (doc.MontoAnticipo > 0)
                {
                    doc.TipoDocAnticipo = doc.TipoDocAnticipo.Substring(0, 2);
                    doc.MonedaAnticipo = monedaAnticipoComboBox.Text;
                }

                var response = await proxy.PostAsJsonAsync("api/invoice", doc);
                RutaArchivo = await response.Content.ReadAsAsync<string>();
                IdDocumento = doc.IdDocumento;

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnCalcDetraccion_Click(object sender, EventArgs e)
        {
            _documento.MontoDetraccion = _documento.Gravadas * _documento.CalculoDetraccion;

            documentoElectronicoBindingSource.ResetBindings(false);
        }

        private void btnGuia_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var datosGuia = _documento.DatosGuiaTransportista ?? new DatosGuia();

                using (var frm = new FrmDatosGuia(datosGuia))
                {
                    if (frm.ShowDialog(this) != DialogResult.OK) return;

                    _documento.DatosGuiaTransportista = datosGuia;
                    documentoElectronicoBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
