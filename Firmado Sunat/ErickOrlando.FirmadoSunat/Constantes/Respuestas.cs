namespace ErickOrlando.FirmadoSunat.Constantes
{
    public static class ErrorGenerico
    {

        public const string Codigo = "10101";
        public const string Mensaje = "Error Genérico detectado";

    }

    public static class ErrorBaseDatos
    {

        public const string Codigo = "10102";
        public const string Mensaje = "Error de Base de Datos";

    }

    public static class ErrorSUNAT
    {

        public const string Codigo = "10103";
        public const string Mensaje = "Error con WebService SUNAT";

    }

    public static class ErrorValidacion
    {
        public const string Codigo = "10104";
        public const string Mensaje = "Error de Validación";
    }

    public static class MensajeExitoso
    {
        public const string Codigo = "10200";
        public const string Mensaje = "Enviado Correctamente";
    }

    public class Constantes
    {
        public const string FormatoFecha = "yyyy-MM-dd";
        public const string FormatoNumerico = "###0.#0";
    }
}

