using System;

namespace OpenInvoicePeru.Entidades
{
    public class Anexo : EntidadBase
    {
        public DateTime FechaGeneracion { get; set; }

        public DateTime FechaRespuesta { get; set; }

        public string XmlFirmado { get; set; }

        public string RepresentacionImpresa { get; set; }

        public short EstadoEnvio { get; set; }

        public string CodigoEstado { get; set; }

        public string DescripcionEstado { get; set; }

        public string CdrSunat { get; set; }

    }
}