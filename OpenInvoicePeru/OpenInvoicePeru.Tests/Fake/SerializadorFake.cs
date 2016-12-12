using System.Threading.Tasks;
using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Firmado;

namespace OpenInvoicePeru.Tests.Fake
{
    public class SerializadorFake : ISerializador
    {
        public async Task<string> GenerarXml<T>(T objectToSerialize) where T : IEstructuraXml
        {
            return await Task.Factory.StartNew(objectToSerialize.ToString);
        }

        async Task<string> ISerializador.GenerarZip(string tramaXml, string nombreArchivo)
        {
            return await Task.Factory.StartNew(() => string.Concat(tramaXml, nombreArchivo));
        }

        async Task<EnviarDocumentoResponse> ISerializador.GenerarDocumentoRespuesta(string constanciaRecepcion)
        {
            var task = Task.Factory.StartNew(() => new EnviarDocumentoResponse
            {
                Exito = true
            });
            return await task;
        }
    }
}