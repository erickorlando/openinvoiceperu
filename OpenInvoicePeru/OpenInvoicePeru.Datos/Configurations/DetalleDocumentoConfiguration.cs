using System.Data.Entity.ModelConfiguration;
using OpenInvoicePeru.Entidades;

namespace OpenInvoicePeru.Datos.Configurations
{
    public class DetalleDocumentoConfiguration : EntityTypeConfiguration<DetalleDocumento>
    {
        public DetalleDocumentoConfiguration()
        {
            Property(e => e.IdUnidadMedida).HasIndex("IX_DetalleDocumento_IdUnidadMedida");

            Property(e => e.IdCabeceraDocumento).HasIndex("IX_DetalleDocumento_IdCabeceraDocumento");
            
        }
    }
}