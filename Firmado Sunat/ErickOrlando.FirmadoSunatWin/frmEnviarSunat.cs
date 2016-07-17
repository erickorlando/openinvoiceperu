using System;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Ionic.Zip;
using OpenInvoicePeru.FirmadoSunat;
using OpenInvoicePeru.FirmadoSunat.Estructuras;
using OpenInvoicePeru.FirmadoSunatWin.Properties;

namespace OpenInvoicePeru.FirmadoSunatWin
{
    public partial class FrmEnviarSunat : Form
    {
        public FrmEnviarSunat()
        {
            InitializeComponent();

            Load += (s, e) => cboTipoDoc.SelectedIndex = 0;
        }

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

        private void btnGen_Click(object sender, EventArgs e)
        {
            try
            {
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
                // Una vez validado el XML seleccionado procedemos con obtener el Certificado.
                var serializar = new Serializador
                {
                    RutaCertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(txtRutaCertificado.Text)),
                    PasswordCertificado = txtPassCertificado.Text,
                    TipoDocumento = rbRetenciones.Checked ? 0 : 1
                };

                // Validacion extra cuando sea un documento de resumen.
                if (rbResumen.Checked) serializar.TipoDocumento = 0;

                using (var conexion = new ConexionSunat(txtNroRuc.Text, txtUsuarioSol.Text,
                    txtClaveSol.Text, rbRetenciones.Checked ? "ServicioSunatRetenciones" : string.Empty))
                {
                    var byteArray = File.ReadAllBytes(txtSource.Text);

                    Cursor = Cursors.WaitCursor;

                    // Firmamos el XML.
                    var tramaFirmado = serializar.FirmarXml(Convert.ToBase64String(byteArray));
                    // Le damos un nuevo nombre al archivo
                    var nombreArchivo = string.Format("{0}-{1}-{2}", txtNroRuc.Text, codigoTipoDoc,
                        txtSerieCorrelativo.Text);
                    // Escribimos el archivo XML ya firmado en una nueva ubicación.
                    using (var fs = File.Create(string.Format("{0}.xml", nombreArchivo)))
                    {
                        var byteFirmado = Convert.FromBase64String(tramaFirmado);
                        fs.Write(byteFirmado, 0, byteFirmado.Length);
                    }

                    // Ahora lo empaquetamos en un ZIP.
                    var tramaZip = serializar.GenerarZip(tramaFirmado, nombreArchivo);

                    if (rbResumen.Checked)
                    {
                        var rptaSunat = conexion.EnviarResumenBaja(tramaZip, string.Format("{0}.zip", nombreArchivo));

                        if (rptaSunat.Item2)
                        {
                            var sb = new StringBuilder();

                            // Añadimos la respuesta del Servicio.
                            sb.AppendLine(Resources.procesoCorrecto);

                            sb.AppendLine(string.Format("Procesamiento correcto, el numero de Ticket es {0}",
                                rptaSunat.Item1));


                            txtResult.Text = sb.ToString();
                            sb.Length = 0;
                        }
                        else
                            txtResult.Text = rptaSunat.Item1;
                    }
                    else
                    {
                        var resultado = conexion.EnviarDocumento(tramaZip, string.Format("{0}.zip", nombreArchivo));

                        if (resultado.Item2)
                        {
                            var returnByte = Convert.FromBase64String(resultado.Item1);

                            var rutaArchivo = string.Format("{0}\\R-{1}.zip", Directory.GetCurrentDirectory(),
                                nombreArchivo);
                            var fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write);
                            fs.Write(returnByte, 0, returnByte.Length);
                            fs.Close();

                            var sb = new StringBuilder();

                            // Añadimos la respuesta del Servicio.
                            sb.AppendLine(Resources.procesoCorrecto);

                            // Extraemos el XML contenido en el archivo de respuesta como un XML.
                            var rutaArchivoXmlRespuesta = rutaArchivo.Replace(".zip", ".xml");
                            // Procedemos a desempaquetar el archivo y leer el contenido de la respuesta SUNAT.
                            using (var streamZip = ZipFile.Read(File.Open(rutaArchivo,
                                FileMode.Open,
                                FileAccess.ReadWrite)))
                            {
                                // Nos aseguramos de que el ZIP contiene al menos un elemento.
                                if (streamZip.Entries.Any())
                                {
                                    if (rbRetenciones.Checked)
                                        streamZip.Entries.Last()
                                        .Extract(".", ExtractExistingFileAction.OverwriteSilently);
                                    else
                                        streamZip.Entries.First()
                                            .Extract(".", ExtractExistingFileAction.OverwriteSilently);
                                }
                            }
                            // Como ya lo tenemos extraido, leemos el contenido de dicho archivo.
                            var xDoc = XDocument.Parse(File.ReadAllText(rutaArchivoXmlRespuesta));

                            var respuesta = xDoc.Descendants(XName.Get("DocumentResponse", EspacioNombres.cac))
                                .Descendants(XName.Get("Response", EspacioNombres.cac))
                                .Descendants().ToList();

                            if (respuesta.Any())
                            {
                                // La respuesta se compone de 3 valores
                                // cbc:ReferenceID
                                // cbc:ResponseCode
                                // cbc:Description
                                // Obtendremos unicamente la Descripción (la última).
                                sb.AppendLine(string.Format("Respuesta de SUNAT a las {0}", DateTime.Now));
                                sb.AppendLine(((XText)respuesta.Nodes().Last()).Value);
                            }

                            txtResult.Text = sb.ToString();
                            sb.Length = 0; // Limpiamos memoria del StringBuilder.
                        }
                        else
                            txtResult.Text = resultado.Item1;
                    }

                }

                //Hablar();
            }
            catch (FaultException exSer)
            {
                txtResult.Text = exSer.ToString();
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

        private void Hablar()
        {
            if (string.IsNullOrEmpty(txtResult.Text)) return;
            var synth = new SpeechSynthesizer();

            synth.SetOutputToDefaultAudioDevice();
            synth.SpeakAsync(txtResult.Text);
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

        private void btnGetStatus_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new FrmTicket())
                {
                    if (frm.ShowDialog() != DialogResult.OK) return;
                    if (string.IsNullOrEmpty(frm.txtNroTicket.Text)) return;


                    using (var conexion = new ConexionSunat(txtNroRuc.Text, txtUsuarioSol.Text,
                        txtClaveSol.Text, rbRetenciones.Checked ? "ServicioSunatRetenciones" : string.Empty))
                    {
                        var resultado = conexion.ObtenerEstado(frm.txtNroTicket.Text);

                        if (resultado.Item2)
                        {
                            var returnByte = Convert.FromBase64String(resultado.Item1);

                            var rutaArchivo = string.Format("{0}\\R-{1}.zip", Directory.GetCurrentDirectory(),
                                frm.txtNroTicket.Text);
                            var fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write);
                            fs.Write(returnByte, 0, returnByte.Length);
                            fs.Close();

                            var sb = new StringBuilder();

                            // Añadimos la respuesta del Servicio.
                            sb.AppendLine(Resources.procesoCorrecto);

                            // Extraemos el XML contenido en el archivo de respuesta como un XML.
                            var rutaArchivoXmlRespuesta = rutaArchivo.Replace(".zip", ".xml");
                            // Procedemos a desempaquetar el archivo y leer el contenido de la respuesta SUNAT.
                            using (var streamZip = ZipFile.Read(File.Open(rutaArchivo,
                                FileMode.Open,
                                FileAccess.ReadWrite, FileShare.ReadWrite)))
                            {
                                // Nos aseguramos de que el ZIP contiene al menos un elemento.
                                if (streamZip.Entries.Any())
                                {
                                    if (rbRetenciones.Checked)
                                        streamZip.Entries.Last()
                                        .Extract(".", ExtractExistingFileAction.OverwriteSilently);
                                    else
                                        streamZip.Entries.First()
                                            .Extract(".", ExtractExistingFileAction.OverwriteSilently);
                                }

                            }
                            // Como ya lo tenemos extraido, leemos el contenido de dicho archivo.
                            var xDoc = XDocument.Parse(File.ReadAllText(rutaArchivoXmlRespuesta));

                            var respuesta = xDoc.Descendants(XName.Get("DocumentResponse", EspacioNombres.cac))
                                .Descendants(XName.Get("Response", EspacioNombres.cac))
                                .Descendants().ToList();

                            if (respuesta.Any())
                            {
                                // La respuesta se compone de 3 valores
                                // cbc:ReferenceID
                                // cbc:ResponseCode
                                // cbc:Description
                                // Obtendremos unicamente la Descripción (la última).
                                sb.AppendLine(string.Format("Respuesta de SUNAT a las {0}", DateTime.Now));
                                sb.AppendLine(((XText)respuesta.Nodes().Last()).Value);
                            }

                            txtResult.Text = sb.ToString();
                            sb.Length = 0; // Limpiamos memoria del StringBuilder.  
                        }
                        else
                            txtResult.Text = resultado.Item1;
                    }

                    Hablar();
                }
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmDocumento())
            {
                frm.ShowDialog(this);
            }
        }
    }
}