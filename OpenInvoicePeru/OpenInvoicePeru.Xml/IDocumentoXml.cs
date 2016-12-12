using OpenInvoicePeru.Comun.Dto.Contratos;
using OpenInvoicePeru.Estructuras;

namespace OpenInvoicePeru.Xml
{
    public interface IDocumentoXml<in TDocumento, out TEstructura>
        where TDocumento : IDocumentoElectronico
        where TEstructura : IEstructuraXml
    {
        TEstructura Generar(TDocumento documento);
    }
}
