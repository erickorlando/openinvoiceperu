using System.Threading.Tasks;
using OpenInvoicePeru.Comun.Dto.Intercambio;

namespace OpenInvoicePeru.Firmado
{
    public interface ICertificador
    {
        Task<FirmadoResponse> FirmarXml(FirmadoRequest request);
    }
}