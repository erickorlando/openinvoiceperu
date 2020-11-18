using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using OpenInvoicePeru.DtoStandard.Intercambio;
using OpenInvoicePeru.DtoStandard.Modelos;

namespace ClienteOip
{
    public partial class MainForm : Form
    {
        private const string UrlSunat = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService";

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using var ofd = new OpenFileDialog
                {
                    Title = @"Ubicar archivo XML", 
                    Filter = @"Archivos XML (*.xml)|*.xml", 
                    FilterIndex = 1
                };
                if (ofd.ShowDialog() != DialogResult.OK) return;

                txtFile.Text = ofd.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                var documento = new DocumentoElectronico
                {
                    Emisor = new Compania
                    {
                        NroDocumento = "20445728269",
                    },
                    IdDocumento = "B001-00111363",
                    TipoDocumento = "03"
                };

                //// Firmado del Documento.
                //var firmado = new FirmadoRequest
                //{
                //    TramaXmlSinFirma = Convert.ToBase64String(File.ReadAllBytes(txtFile.Text)),
                //    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("certificado.pfx")),
                //    PasswordCertificado = string.Empty,
                //};

                //var responseFirma = RestHelper<FirmadoRequest, FirmadoResponse>.Execute("Firmar", firmado);

                //if (!responseFirma.Exito)
                //{
                //    throw new InvalidOperationException(responseFirma.MensajeError);
                //}

                var sb = new StringBuilder();

                //sb.AppendFormat("Escribiendo el archivo {0}.xml .....", documento.IdDocumento);

                //var path = $"{documento.IdDocumento}.xml";
                //File.WriteAllBytes(path, Convert.FromBase64String(responseFirma.TramaXmlFirmado));
                //Process.Start(path);

                sb.AppendLine("Enviando a SUNAT....");

                var documentoRequest = new EnviarDocumentoRequest
                {
                    Ruc = documento.Emisor.NroDocumento,
                    UsuarioSol = "MODDATOS",
                    ClaveSol = "MODDATOS",
                    EndPointUrl = UrlSunat,
                    IdDocumento = documento.IdDocumento,
                    TipoDocumento = documento.TipoDocumento,
                    TramaXmlFirmado = Convert.ToBase64String(File.ReadAllBytes(txtFile.Text))
                };

                var enviarDocumentoResponse = RestHelper<EnviarDocumentoRequest, EnviarDocumentoResponse>.Execute("EnviarDocumento", documentoRequest);

                if (!enviarDocumentoResponse.Exito)
                {
                    throw new InvalidOperationException(enviarDocumentoResponse.MensajeError);
                }

                File.WriteAllBytes($"{documento.IdDocumento}.zip", 
                    Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr));

                sb.AppendLine("Respuesta de SUNAT:");
                sb.AppendLine(enviarDocumentoResponse.MensajeRespuesta);

                lblStatus.Text = sb.ToString();
                sb.Length = 0;
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }

        }
    }
}
