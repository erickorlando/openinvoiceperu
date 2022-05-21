using System;
using System.Drawing.Imaging;
using System.IO;
using ZXing;
using ZXing.QrCode;

namespace OpenInvoicePeru.ApiRest.Utils
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
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Width = 800,
                    Height = 800
                }
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