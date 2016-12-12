using System.Threading.Tasks;
using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Dto.Intercambio;

namespace OpenInvoicePeru.Firmado
{
    public interface ISerializador
    {
        Task<string> GenerarXml<T>(T objectToSerialize) where T : IEstructuraXml;
        Task<string> GenerarZip(string tramaXml, string nombreArchivo);
        Task<EnviarDocumentoResponse> GenerarDocumentoRespuesta(string constanciaRecepcion);
    }
}