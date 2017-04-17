using System;
using System.IO;
using System.Windows.Forms;

namespace OpenInvoicePeru.WinApp
{
    public static class Program
    {
        public static string CarpetaXml => "./XML";
        public static string CarpetaCdr => "./CDR";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (!Directory.Exists(CarpetaXml))
                    Directory.CreateDirectory(CarpetaXml);
                if (!Directory.Exists(CarpetaCdr))
                    Directory.CreateDirectory(CarpetaCdr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException?.Message, Application.ProductName);
            }
            Application.Run(new FrmEnviarSunat());
        }
    }
}
