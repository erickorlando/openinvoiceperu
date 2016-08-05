using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Speech.Synthesis;
using System.Windows.Forms;
using OpenInvoicePeru.FirmadoSunat.Models;
using OpenInvoicePeru.FirmadoSunatWin.Properties;

namespace OpenInvoicePeru.FirmadoSunatWin
{
    public partial class FrmEnviarSunat : Form
    {
        #region Variables Privadas
        private FrmDocumento _frmDocumento;
        private readonly HttpClient _client;
        #endregion

        #region Constructor
        public FrmEnviarSunat()
        {
            InitializeComponent();

            _client = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlOpenInvoicePeruApi"]) };

            Load += (s, e) =>
            {

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    cboTipoDoc.SelectedIndex = 0;
                    cboUrlServicio.DisplayMember = "Item1";
                    cboUrlServicio.ValueMember = "Item2";
                    // Cargamos las URL provistas por el archivo de Texto.
                    var lineas = File.ReadAllLines("DireccionesSunat.txt");
                    foreach (var linea in lineas)
                    {
                        var valores = linea.Split('|');
                        var servicio = new Tuple<string, string>(valores.First(), valores.Last());

                        cboUrlServicio.Items.Add(servicio);
                    }

                    cboUrlServicio.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            };
        }
        #endregion

        #region Botones de Busqueda
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = Resources.seleccionXml;
                    ofd.Filter = Resources.formatosXml;
                    ofd.FilterIndex = 1;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtSource.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowseCert_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = Resources.seleccioneCertificado;
                    ofd.Filter = Resources.formatosCertificado;
                    ofd.FilterIndex = 1;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtRutaCertificado.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region LLamadas Asincronas
        private async void btnGen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string codigoTipoDoc;
                switch (cboTipoDoc.SelectedIndex)
                {
                    case 0:
                        codigoTipoDoc = "01";
                        break;
                    case 1:
                        codigoTipoDoc = "03";
                        break;
                    case 2:
                        codigoTipoDoc = "07";
                        break;
                    case 3:
                        codigoTipoDoc = "08";
                        break;
                    case 4:
                        codigoTipoDoc = "20";
                        break;
                    case 5:
                        codigoTipoDoc = "40";
                        break;
                    case 6:
                        codigoTipoDoc = "RC";
                        break;
                    case 7:
                        codigoTipoDoc = "RA";
                        break;
                    default:
                        codigoTipoDoc = "01";
                        break;
                }

                var tramaXmlSinFirma = Convert.ToBase64String(File.ReadAllBytes(txtSource.Text));

                var firmadoRequest = new FirmadoRequest
                {
                    TramaXmlSinFirma = tramaXmlSinFirma,
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(txtRutaCertificado.Text)),
                    PasswordCertificado = txtPassCertificado.Text,
                    UnSoloNodoExtension = rbRetenciones.Checked
                };

                var jsonFirmado = await _client.PostAsJsonAsync("api/Firmar", firmadoRequest);
                var respuestaFirmado = await jsonFirmado.Content.ReadAsAsync<FirmadoResponse>();
                if (!respuestaFirmado.Exito)
                    throw new ApplicationException(respuestaFirmado.MensajeError);

                var enviarDocumentoRequest = new EnviarDocumentoRequest
                {
                    Ruc = txtNroRuc.Text,
                    UsuarioSol = txtUsuarioSol.Text,
                    ClaveSol = txtClaveSol.Text,
                    EndPointUrl = ValorSeleccionado(),
                    IdDocumento = txtSerieCorrelativo.Text,
                    TipoDocumento = codigoTipoDoc,
                    TramaXmlFirmado = respuestaFirmado.TramaXmlFirmado
                };

                var jsonEnvioDocumento = await _client.PostAsJsonAsync("api/EnviarDocumento", enviarDocumentoRequest);

                var respuestaEnvio = await jsonEnvioDocumento.Content.ReadAsAsync<EnviarDocumentoResponse>();

                if (!respuestaEnvio.Exito)
                    throw new ApplicationException(respuestaEnvio.MensajeError);

                txtResult.Text = $"{Resources.procesoCorrecto}{Environment.NewLine}{respuestaEnvio.MensajeRespuesta}";

                if (chkVoz.Checked)
                    Hablar();
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void btnGetStatus_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                using (var frm = new FrmTicket())
                {
                    if (frm.ShowDialog() != DialogResult.OK) return;
                    if (string.IsNullOrEmpty(frm.txtNroTicket.Text)) return;


                    var consultaTicketRequest = new ConsultaTicketRequest
                    {
                        Ruc = txtNroRuc.Text,
                        UsuarioSol = txtUsuarioSol.Text,
                        ClaveSol = txtClaveSol.Text,
                        EndPointUrl = ValorSeleccionado(),
                        IdDocumento = txtSerieCorrelativo.Text,
                        NroTicket = frm.txtNroTicket.Text
                    };

                    var jsonConsultaTicket = await _client.PostAsJsonAsync("api/ConsultarTicket", consultaTicketRequest);

                    var respuestaEnvio = await jsonConsultaTicket.Content.ReadAsAsync<EnviarDocumentoResponse>();

                    if (!respuestaEnvio.Exito)
                        throw new ApplicationException(respuestaEnvio.MensajeError);

                    txtResult.Text = $"{Resources.procesoCorrecto}{Environment.NewLine}{respuestaEnvio.MensajeRespuesta}";

                    Hablar();
                }
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Generacion de XML
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_frmDocumento == null)
                {
                    if (string.IsNullOrEmpty(txtNroRuc.Text))
                        _frmDocumento = new FrmDocumento();
                    else
                    {
                        var documento = new DocumentoElectronico
                        {
                            Emisor = { NroDocumento = txtNroRuc.Text },
                            FechaEmision = DateTime.Today.ToShortDateString()
                        };
                        _frmDocumento = new FrmDocumento(documento);
                    }
                }
                var rpta = _frmDocumento.ShowDialog(this);

                if (rpta != DialogResult.OK) return;

                txtSource.Text = _frmDocumento.RutaArchivo;
                txtSerieCorrelativo.Text = _frmDocumento.IdDocumento;

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

        #region Metodos Privados
        private void Hablar()
        {
            if (string.IsNullOrEmpty(txtResult.Text)) return;
            var synth = new SpeechSynthesizer();

            synth.SetOutputToDefaultAudioDevice();
            synth.SpeakAsync(txtResult.Text);
        }

        private string ValorSeleccionado()
        {
            var tupla = cboUrlServicio.SelectedItem as Tuple<string, string>;
            return tupla == null ? string.Empty : tupla.Item2;
        } 
        #endregion
    }
}