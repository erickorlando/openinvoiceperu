using OpenInvoicePeru.Entidades;

namespace OpenInvoicePeru.Datos.Configurations
{
    public class AnexoConfiguration : BaseConfigurationEntity<Anexo>
    {
        public AnexoConfiguration()
        {
            Property(p => p.FechaGeneracion)
                .IsRequired();

            Property(p => p.FechaRespuesta)
                .IsOptional();

            Property(p => p.CodigoEstado)
                .HasMaxLength(1)
                .IsOptional();

            Property(p => p.DescripcionEstado)
                .HasMaxLength(250)
                .IsOptional();

            Property(p => p.CdrSunat)
                .IsOptional();

            Property(p => p.EstadoEnvio)
                .IsRequired();

            Property(p => p.XmlFirmado)
                .IsRequired();

            Property(p => p.RepresentacionImpresa)
                .IsRequired();
        }
    }
}