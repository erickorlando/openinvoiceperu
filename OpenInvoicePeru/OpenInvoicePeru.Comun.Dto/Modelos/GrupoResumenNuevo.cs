namespace OpenInvoicePeru.Comun.Dto.Modelos
{
    public class GrupoResumenNuevo : GrupoResumen
    {
        public string NroDocumentoReceptor { get; set; }
        public string TipoDocumentoReceptor { get; set; }
        public string IdDocumento { get; set; }
        public int CodigoEstadoItem { get; set; }
        public string DocumentoRelacionado { get; set; }
        public string TipoDocumentoRelacionado { get; set; }
    }
}