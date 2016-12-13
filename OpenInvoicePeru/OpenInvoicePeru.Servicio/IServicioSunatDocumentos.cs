namespace OpenInvoicePeru.Servicio
{
    public interface IServicioSunatDocumentos : IServicioSunat
    {
        RespuestaSincrono EnviarDocumento(DocumentoSunat request);
        RespuestaAsincrono EnviarResumen(DocumentoSunat request);
        RespuestaSincrono ConsultarTicket(string numeroTicket);
    }
}