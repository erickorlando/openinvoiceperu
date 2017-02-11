namespace OpenInvoicePeru.Comun.Dto.Intercambio
{
    public abstract class RespuestaComun
    {
        public bool Exito { get; set; }

        public string MensajeError { get; set; }

        public string Pila { get; set; }
    }
}