using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using ErickOrlando.FirmadoSunat;
using ErickOrlando.FirmadoSunatWin.Properties;
using Ionic.Zip;
using ErickOrlando.FirmadoSunat.Estructuras;

namespace ErickOrlando.FirmadoSunatWin
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

                using (var conexion = new ConexionSunat(txtNroRuc.Text, txtUsuarioSol.Text,
                    txtClaveSol.Text, rbRetenciones.Checked ? "ServicioSunatRetenciones" : string.Empty))
                {

                    var byteArray = File.ReadAllBytes(txtSource.Text);

                    Cursor = Cursors.WaitCursor;

                    // Firmamos el XML.
                    var tramaFirmado = serializar.FirmarXml(Convert.ToBase64String(byteArray));
                    // Le damos un nuevo nombre al archivo
                    var nombreArchivo = $"{txtNroRuc.Text}-{codigoTipoDoc}-{txtSerieCorrelativo.Text}";
                    // Ahora lo empaquetamos en un ZIP.
                    var tramaZip = serializar.GenerarZip(tramaFirmado, nombreArchivo);

                    var resultado = conexion.EnviarDocumento(tramaZip, $"{nombreArchivo}.zip");

                    if (resultado.Item2)
                    {
                        var returnByte = Convert.FromBase64String(resultado.Item1);

                        var rutaArchivo = $"{Directory.GetCurrentDirectory()}\\R-{nombreArchivo}.zip";
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
                            sb.AppendLine(((XText)respuesta.Nodes().Last()).Value);
                        }

                        txtResult.Text = sb.ToString();
                        sb.Length = 0; // Limpiamos memoria del StringBuilder.
                    }
                    else
                        txtResult.Text = resultado.Item1;

                }
            }
            catch (System.ServiceModel.FaultException exSer)
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
    }
}
