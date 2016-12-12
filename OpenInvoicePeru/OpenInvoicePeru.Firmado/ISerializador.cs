using OpenInvoicePeru.Comun;

namespace OpenInvoicePeru.Firmado
{
    public interface ISerializador
    {
        string GenerarXml<T>(T objectToSerialize) where T : IEstructuraXml;
        string GenerarZip(string tramaXml, string nombreArchivo);
    }
}