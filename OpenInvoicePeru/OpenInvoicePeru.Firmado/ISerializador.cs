namespace OpenInvoicePeru.Firmado
{
    public interface ISerializador
    {
        string GenerarXml<T>(T objectToSerialize);
        string GenerarZip(string tramaXml, string nombreArchivo);
    }
}