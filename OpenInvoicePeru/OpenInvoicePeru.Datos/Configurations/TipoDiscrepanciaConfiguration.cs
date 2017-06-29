using OpenInvoicePeru.Entidades;

namespace OpenInvoicePeru.Datos.Configurations
{
    public class TipoDiscrepanciaConfiguration : BaseConfigurationEntity<TipoDiscrepancia>
    {
        public TipoDiscrepanciaConfiguration()
        {
            Property(p => p.IdTipoDocumento).HasIndex(Prefix + "IdTipoDoc");

            HasRequired(p => p.TipoDocumento)
                .WithMany()
                .HasForeignKey(p => p.IdTipoDocumento)
                .WillCascadeOnDelete(false);
        }
    }
}