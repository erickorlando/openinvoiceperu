using System;
using System.Drawing.Imaging;
using System.IO;
using ZXing;

namespace OpenInvoicePeru.WebApi.Utils
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class QrHelper
    {
        /// <summary>
        /// Permite generar la imagen para QR en formato PNG.
        /// </summary>
        /// <param name="parameter">Trama a generar</param>
        public static string GenerarImagenQr(string parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE
            };

            using (var mem = new MemoryStream())
            {
                var imagen = barcodeWriter.Write(parameter);
                imagen.Save(mem, ImageFormat.Png);

                return Convert.ToBase64String(mem.ToArray());
            }
        }
    }
}