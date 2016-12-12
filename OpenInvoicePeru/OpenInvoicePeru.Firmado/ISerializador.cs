using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Dto.Intercambio;

namespace OpenInvoicePeru.Firmado
{
    public interface ISerializador
    {
        string GenerarXml<T>(T objectToSerialize) where T : IEstructuraXml;
        string GenerarZip(string tramaXml, string nombreArchivo);
        EnviarDocumentoResponse GenerarDocumentoRespuesta(string constanciaRecepcion);
    }
}