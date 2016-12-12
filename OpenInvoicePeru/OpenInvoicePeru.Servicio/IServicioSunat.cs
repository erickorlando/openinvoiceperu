namespace OpenInvoicePeru.Servicio
{
    public interface IServicioSunat
    {
        RespuestaSincrono EnviarDocumento(DocumentoSunat request);
        RespuestaAsincrono EnviarResumen(DocumentoSunat request);
        RespuestaSincrono ConsultarTicket(string numeroTicket);
        RespuestaSincrono ConsultarConstanciaDeRecepcion(DatosDocumento request);
    }
}