using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Comun.Dto.Contratos;

namespace OpenInvoicePeru.Xml
{
    public interface IDocumentoXml
    {
        IEstructuraXml Generar(IDocumentoElectronico request);
    }
}
