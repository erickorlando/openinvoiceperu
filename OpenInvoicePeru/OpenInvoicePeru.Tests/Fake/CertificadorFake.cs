using System.Threading.Tasks;
using Moq;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Firmado;

namespace OpenInvoicePeru.Tests.Fake
{
    public class CertificadorFake : ICertificador
    {
        async Task<FirmadoResponse> ICertificador.FirmarXml(FirmadoRequest request)
        {
            return await Task.Factory.StartNew(It.IsAny<FirmadoResponse>);
        }
    }
}