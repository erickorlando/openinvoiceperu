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
        public FrmDocumento()
        {
            InitializeComponent();
            _documento = new DocumentoElectronico
            {
                FechaEmision = DateTime.Today.ToShortDateString(),
                IdDocumento = "FF11-00001"
            };

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
            var detalle = new DetalleDocumento();

            using (var frm = new FrmDetalleDocumento(detalle, _documento))
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                _documento.Items.Add(detalle);

                CalcularTotales();
            }
        }

        private void CalcularTotales()
        {
            // Realizamos los cálculos respectivos.
            _documento.TotalIgv = _documento.Items.Sum(d => d.Impuesto);
            _documento.TotalIsc = _documento.Items.Sum(d => d.ImpuestoSelectivo);
            _documento.TotalOtrosTributos = _documento.Items.Sum(d => d.OtroImpuesto);
            _documento.TotalVenta = _documento.Items.Sum(d => d.TotalVenta);

            _documento.Gravadas = _documento.Items
                .Where(d => d.TipoImpuesto.Contains("Gravado"))
                .Sum(d => d.Suma);

            _documento.Exoneradas = _documento.Items
                .Where(d => d.TipoImpuesto.Contains("20"))
                .Sum(d => d.Suma);

            _documento.Inafectas = _documento.Items
                .Where(d => d.TipoImpuesto.Contains("Inafecto"))
                .Sum(d => d.Suma);

            _documento.Gratuitas = _documento.Items
                .Where(d => d.TipoImpuesto.Contains("21"))
                .Sum(d => d.Suma);

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
                var proxy = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlOpenInvoicePeruApi"]) };

                var doc = (DocumentoElectronico)_documento.Clone();

                doc.Emisor = emisorBindingSource.Current as Contribuyente;
                doc.Emisor.TipoDocumento = "6";

                doc.Receptor = receptorBindingSource.Current as Contribuyente;

                doc.Moneda = cboMoneda.SelectedText;

                foreach (var item in doc.Items)
                {
                    item.TipoImpuesto = item.TipoImpuesto.Substring(0, 2);
                    item.TipoPrecio = item.TipoPrecio.Substring(0, 2);
                }

                var response = await proxy.PostAsJsonAsync("api/invoice", doc);
                RutaArchivo = await response.Content.ReadAsAsync<string>();

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
    }
}
