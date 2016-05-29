using System;
using System.ServiceModel;
using ErickOrlando.FirmadoSunat.Sunat;

namespace ErickOrlando.FirmadoSunat
{
    /// <summary>
    /// Clase para la conexión con el WS de SUNAT
    /// </summary>
    public class ConexionSunat : IDisposable
    {
        private billServiceClient _proxy;

        /// <summary>
        /// Nombre del Endpoint que referencia al Servicio de SUNAT
        /// </summary>
        public string EndPointServicio { get; set; }
        /// <summary>
        /// Constructor de la Clase ConexionSunat
        /// </summary>
        /// <param name="ruc">Numero de RUC del contribuyente</param>
        /// <param name="username">Usuario SOL</param>
        /// <param name="password">Clave SOL</param>
        /// <param name="endPointServicio">Nombre del Endpoint (Opcional)</param>
        public ConexionSunat(string ruc, string username, string password, string endPointServicio = null)
        {
            System.Net.ServicePointManager.UseNagleAlgorithm = true;
            System.Net.ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.CheckCertificateRevocationList = true;

            EndPointServicio = string.IsNullOrEmpty(endPointServicio) ? "ServicioSunat" : endPointServicio;

            _proxy = new billServiceClient(EndPointServicio);


            // Agregamos el behavior configurado para soportar WS-Security.
            var behavior = new PasswordDigestBehavior(string.Concat(ruc, username), password);
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
                response = new Tuple<string, bool>(EndPointServicio == "ServicioSunat"
                    ? ex.Code.Name : ex.Message, false);
            }
            catch (Exception ex)
            {
                var msg = string.Concat(ex.InnerException.Message ?? string.Empty, ex.Message);
                var faultCode = "<faultcode>";
                if (msg.Contains(faultCode))
                {
                    var posicion = msg.IndexOf(faultCode, StringComparison.Ordinal);
                    var codigoError = msg.Substring(posicion + faultCode.Length, 4);
                    msg = string.Format("El Código de Error es {0}", codigoError);
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
                var msg = string.Concat(ex.InnerException?.Message ?? string.Empty, ex.Message);
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
                var msg = string.Concat(ex.InnerException?.Message ?? string.Empty, ex.Message);
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

        protected virtual void Dispose(bool disposing)
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
