using System;
using System.ServiceModel;
using OpenInvoicePeru.FirmadoSunat.Service_References.Sunat;

namespace OpenInvoicePeru.FirmadoSunat
{
    /// <summary>
    /// Clase para la conexión con el WS de SUNAT
    /// </summary>
    public sealed class ConexionSunat : IDisposable
    {
        public class Parametros
        {
            public string Ruc { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool Retencion { get; set; }
            public string EndPointUrl { get; set; }
        }

        private billServiceClient _proxy;

        private bool Retencion { get; set; }

        public ConexionSunat(Parametros parametros)
        {
            System.Net.ServicePointManager.UseNagleAlgorithm = true;
            System.Net.ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.CheckCertificateRevocationList = true;

            _proxy = new billServiceClient("ServicioSunat", parametros.EndPointUrl);
            Retencion = parametros.Retencion;

            // Agregamos el behavior configurado para soportar WS-Security.
            var behavior = new PasswordDigestBehavior(string.Concat(parametros.Ruc, parametros.UserName), parametros.Password);
            _proxy.Endpoint.EndpointBehaviors.Add(behavior);
        }
        /// <summary>
        /// Enviar documento ZIP al WS Sunat
        /// </summary>
        /// <param name="tramaArchivo">Cadena Base64 de la trama del archivo</param>
        /// <param name="nombreArchivo">Nombre del archivo (sin extension)</param>
        /// <returns>Devuelve una tupla con la cadena Base64 del ZIP de respuesta (CDR) y un booleano si SUNAT responde correctamente</returns>
        public Tuple<string, bool> EnviarDocumento(string tramaArchivo, string nombreArchivo)
        {
            var dataOrigen = Convert.FromBase64String(tramaArchivo);
            Tuple<string, bool> response;

            try
            {
                _proxy.Open();
                var resultado = _proxy.sendBill(nombreArchivo, dataOrigen);

                _proxy.Close();

                response = new Tuple<string, bool>(Convert.ToBase64String(resultado), true);
            }
            catch (FaultException ex)
            {
                response = new Tuple<string, bool>(!Retencion
                    ? ex.Code.Name : ex.Message, false);
            }
            catch (Exception ex)
            {
                var msg = string.Concat(ex.InnerException.Message, ex.Message);
                var faultCode = "<faultcode>";
                if (msg.Contains(faultCode))
                {
                    var posicion = msg.IndexOf(faultCode, StringComparison.Ordinal);
                    var codigoError = msg.Substring(posicion + faultCode.Length, 4);
                    msg = $"El Código de Error es {codigoError}";
                }
                response = new Tuple<string, bool>(msg, false);
            }

            return response;
        }
        /// <summary>
        /// Envia el Resumen de Baja basado en la cadena Base64 del archivo ZIP
        /// </summary>
        /// <param name="tramaArchivo">Cadena Base64 del archivo ZIP</param>
        /// <param name="nombreArchivo">Nombre del archivo (sin extension)</param>
        /// <returns>Devuelve una tupla con el numero de Ticket del CDR y un booleano si SUNAT responde correctamente</returns>
        public Tuple<string, bool> EnviarResumenBaja(string tramaArchivo, string nombreArchivo)
        {
            var dataOrigen = Convert.FromBase64String(tramaArchivo);
            Tuple<string, bool> response;

            try
            {
                _proxy.Open();
                var resultado = _proxy.sendSummary(nombreArchivo, dataOrigen);

                _proxy.Close();

                response = new Tuple<string, bool>(resultado, true);
            }
            catch (FaultException ex)
            {
                response = new Tuple<string, bool>(ex.Code.Name, false);
            }
            catch (Exception ex)
            {
                string msg;
                msg = ex.InnerException != null ? string.Concat(ex.InnerException.Message, ex.Message) : ex.Message;
                var faultCode = "<faultcode>";
                if (msg.Contains(faultCode))
                {
                    var posicion = msg.IndexOf(faultCode, StringComparison.Ordinal);
                    var codigoError = msg.Substring(posicion + faultCode.Length, 4);
                    msg = $"El Código de Error es {codigoError}";
                }
                response = new Tuple<string, bool>(msg, false);
            }

            return response;
        }
        /// <summary>
        /// Devuelve el estado de un CDR basado en el numero de Ticket
        /// </summary>
        /// <param name="numeroTicket">Numero de Ticket proporcionado por SUNAT</param>
        /// <returns>Devuelve una tupla con la cadena Base64 del ZIP de respuesta (CDR) y un booleano si SUNAT responde con el estado correcto</returns>
        public Tuple<string, bool> ObtenerEstado(string numeroTicket)
        {
            Tuple<string, bool> response;

            try
            {
                _proxy.Open();
                var resultado = _proxy.getStatus(numeroTicket);

                _proxy.Close();

                var estado = (resultado.statusCode != "98");

                response = new Tuple<string, bool>(estado
                    ? Convert.ToBase64String(resultado.content) : "Aun en proceso", estado);
            }
            catch (FaultException ex)
            {
                response = new Tuple<string, bool>(ex.Code.Name, false);
            }
            catch (Exception ex)
            {
                string msg;
                msg = ex.InnerException != null ? string.Concat(ex.InnerException.Message, ex.Message) : ex.Message;
                var faultCode = "<faultcode>";
                if (msg.Contains(faultCode))
                {
                    var posicion = msg.IndexOf(faultCode, StringComparison.Ordinal);
                    var codigoError = msg.Substring(posicion + faultCode.Length, 4);
                    msg = $"El Código de Error es {codigoError}";
                }
                response = new Tuple<string, bool>(msg, false);
            }

            return response;
        }

        #region IDisposable Support
        private bool _disposedValue; // To detect redundant calls

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _proxy = null;
                }

                _disposedValue = true;
            }
        }

        // ~Connect() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
