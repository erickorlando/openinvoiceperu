using OpenInvoicePeru.Comun.Dto.Intercambio;

namespace OpenInvoicePeru.Firmado
{
    public interface ICertificador
    {
        FirmadoResponse FirmarXml(FirmadoRequest request);
    }
}