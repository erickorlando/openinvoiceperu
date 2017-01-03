using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Datos;

namespace OpenInvoicePeru.WinApp
{
    public partial class FrmDocumento : PlantillaBase
    {
        #region Variables Privadas
        private readonly DocumentoElectronico _documento;
        #endregion

        #region Propiedades
        public string RutaArchivo { get; set; }
        public string IdDocumento { get; set; }
        #endregion

        #region Constructores
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
        #endregion

        #region Evento Load
        private void FrmDocumento_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                using (var ctx = new OpenInvoicePeruDb())
                {
                    tipoDocumentoBindingSource.DataSource = ctx.TipoDocumentos.ToList();
                    tipoDocumentoBindingSource.ResetBindings(false);

                    tipoDocumentoContribuyenteBindingSource.DataSource = ctx.TipoDocumentoContribuyentes.ToList();
                    tipoDocumentoContribuyenteBindingSource.ResetBindings(false);

                    tipoDocumentoAnticipoBindingSource.DataSource = ctx.TipoDocumentoAnticipos.ToList();
                    tipoDocumentoAnticipoBindingSource.ResetBindings(false);

                    tipoOperacionBindingSource.DataSource = ctx.TipoOperaciones.ToList();
                    tipoOperacionBindingSource.ResetBindings(false);

                    monedaBindingSource.DataSource = ctx.Monedas.ToList();
                    monedaBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        } 
        #endregion

        #region Metodos Privados

        private void Inicializar()
        {
            documentoElectronicoBindingSource.DataSource = _documento;
            documentoElectronicoBindingSource.ResetBindings(false);

            emisorBindingSource.DataSource = _documento.Emisor;
            emisorBindingSource.ResetBindings(false);

            receptorBindingSource.DataSource = _documento.Receptor;
            receptorBindingSource.ResetBindings(false);
        }

        private void CalcularTotales()
        {
            // Realizamos los cálculos respectivos.
            _documento.TotalIgv = _documento.Items.Sum(d => d.Impuesto);
            _documento.TotalIsc = _documento.Items.Sum(d => d.ImpuestoSelectivo);
            _documento.TotalOtrosTributos = _documento.Items.Sum(d => d.OtroImpuesto);

            _documento.Gravadas = _documento.Items
                .Where(d => d.TipoImpuesto.StartsWith("1"))
                .Sum(d => d.Suma);

            _documento.Exoneradas = _documento.Items
                .Where(d => d.TipoImpuesto.Contains("20"))
                .Sum(d => d.Suma);

            _documento.Inafectas = _documento.Items
                .Where(d => d.TipoImpuesto.StartsWith("3") || d.TipoImpuesto.Contains("40"))
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

        #endregion

        #region Detalles
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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
                        }
                        break;
                    case 2:
                        var documentoRelacionado = new DocumentoRelacionado();
                        using (var frm = new FrmDocumentoRelacionado(documentoRelacionado))
                        {
                            if (frm.ShowDialog(this) != DialogResult.OK) return;

                            _documento.Relacionados.Add(documentoRelacionado);
                        }
                        break;
                    case 3:
                        var discrepancia = new Discrepancia();
                        using (var frm = new FrmDiscrepancia(discrepancia, _documento.TipoDocumento))
                        {
                            if (frm.ShowDialog(this) != DialogResult.OK) return;

                            _documento.Discrepancias.Add(discrepancia);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                documentoElectronicoBindingSource.ResetBindings(false);
                Cursor.Current = Cursors.Default;
            }

        }

        private void btnDuplicar_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var registro = detallesBindingSource.Current as DetalleDocumento;
                if (registro == null) throw new ArgumentNullException(nameof(registro));

                var copia = new DetalleDocumento
                {
                    Id = registro.Id,
                    Cantidad = registro.Cantidad,
                    CodigoItem = registro.CodigoItem,
                    Descripcion = registro.Descripcion,
                    PrecioUnitario = registro.PrecioUnitario,
                    PrecioReferencial = registro.PrecioReferencial,
                    UnidadMedida =  registro.UnidadMedida,
                    Impuesto = registro.Impuesto,
                    ImpuestoSelectivo = registro.ImpuestoSelectivo,
                    TipoImpuesto = registro.TipoImpuesto,
                    TipoPrecio = registro.TipoPrecio,
                    TotalVenta = registro.TotalVenta,
                    Suma = registro.Suma,
                    OtroImpuesto = registro.OtroImpuesto
                };

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

                switch (tbPaginas.SelectedIndex)
                {
                    case 0:
                        var registro = detallesBindingSource.Current as DetalleDocumento;
                        if (registro == null) return;

                        _documento.Items.Remove(registro);

                        CalcularTotales();
                        break;
                    case 1:
                        var docAdicional = datoAdicionalesBindingSource.Current as DatoAdicional;
                        if (docAdicional == null) return;

                        _documento.DatoAdicionales.Remove(docAdicional);
                        break;
                    case 2:
                        var docRelacionado = relacionadosBindingSource.Current as DocumentoRelacionado;
                        if (docRelacionado == null) return;

                        _documento.Relacionados.Remove(docRelacionado);
                        break;
                    case 3:
                        var discrepancia = discrepanciasBindingSource.Current as Discrepancia;
                        if (discrepancia == null) return;

                        _documento.Discrepancias.Remove(discrepancia);
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                documentoElectronicoBindingSource.ResetBindings(false);
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        #region Botones Adicionales
        private void btnCalcDetraccion_Click(object sender, EventArgs e)
        {
            _documento.MontoDetraccion = _documento.TotalVenta * _documento.CalculoDetraccion;

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
        #endregion

        #region Generar XML
        private async void toolGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                documentoElectronicoBindingSource.EndEdit();
                totalVentaTextBox.Focus();

                var proxy = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlOpenInvoicePeruApi"]) };

                string metodoApi;
                switch (_documento.TipoDocumento)
                {
                    case "07":
                        metodoApi = "api/GenerarNotaCredito";
                        break;
                    case "08":
                        metodoApi = "api/GenerarNotaDebito";
                        break;
                    default:
                        metodoApi = "api/GenerarFactura";
                        break;
                }

                var response = await proxy.PostAsJsonAsync(metodoApi, _documento);
                var respuesta = await response.Content.ReadAsAsync<DocumentoResponse>();
                if (!respuesta.Exito)
                    throw new ApplicationException(respuesta.MensajeError);

                RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                    $"{_documento.IdDocumento}.xml");

                File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(respuesta.TramaXmlSinFirma));

                IdDocumento = _documento.IdDocumento;

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
        #endregion

    }
}
