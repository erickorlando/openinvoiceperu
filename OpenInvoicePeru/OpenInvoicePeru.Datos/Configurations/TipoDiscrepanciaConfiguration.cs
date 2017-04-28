using System.Data.Entity.ModelConfiguration;
using OpenInvoicePeru.Entidades;

namespace OpenInvoicePeru.Datos.Configurations
{
    public class TipoDiscrepanciaConfiguration : EntityTypeConfiguration<TipoDiscrepancia>
    {
        public TipoDiscrepanciaConfiguration()
        {
            Property(p => p.IdTipoDocumento).HasIndex("IX_TipoDiscrepancia_IdTipoDoc");

            HasRequired(p => p.TipoDocumento)
                .WithMany()
                .HasForeignKey(p => p.IdTipoDocumento)
                .WillCascadeOnDelete(false);
        }
    }
}