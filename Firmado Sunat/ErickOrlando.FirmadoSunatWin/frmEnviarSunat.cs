using System;
using System.IO;
using System.Windows.Forms;
using ErickOrlando.FirmadoSunat;

namespace ErickOrlando.FirmadoSunatWin
{
    public partial class FrmEnviarSunat : Form
    {
        public FrmEnviarSunat()
        {
            InitializeComponent();
#if (DEBUG)
            txtSource.Text = @"..\Debug\DocumentosEjemplo\20101295673-01-FF11-01.zip";

#else

            txtSource.Text = @"..\Release\DocumentosEjemplo\20101295673-01-FF11-01.zip";
#endif

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = "Seleccione un Documento SUNAT";
                    ofd.Filter = "Documentos (*.zip)|*.zip";
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

                using (var conexion = new ConexionSunat("20101295673", "MODDATOS", "MODDATOS"))
                {

                    var fileZip = Path.GetFileName(txtSource.Text);

                    var byteArray = File.ReadAllBytes(txtSource.Text);

                    Cursor = Cursors.WaitCursor;

                    var resultado = conexion.EnviarDocumento(Convert.ToBase64String(byteArray), fileZip);

                    if (resultado.Item2)
                    {
                        var returnByte = Convert.FromBase64String(resultado.Item1);

                        var fs = new FileStream(Directory.GetCurrentDirectory() + "R-" + fileZip + ".zip", FileMode.Create);
                        fs.Write(returnByte, 0, returnByte.Length);
                        fs.Close();

                        txtResult.Text = @"Todo correcto!";
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
    }
}
