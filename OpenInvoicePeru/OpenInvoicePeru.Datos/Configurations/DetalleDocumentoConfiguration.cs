using OpenInvoicePeru.Entidades;

namespace OpenInvoicePeru.Datos.Configurations
{
    public class DetalleDocumentoConfiguration : BaseConfigurationEntity<DocumentoDetalle>
    {
        public DetalleDocumentoConfiguration()
        {
            Property(e => e.IdUnidadMedida).HasIndex(Prefix + "IdUnidadMedida");

            Property(e => e.IdCabeceraDocumento).HasIndex(Prefix + "IdCabeceraDocumento");

            Property(e => e.IdTipoPrecio).HasIndex(Prefix + "IdTipoPrecio");

            HasRequired(p => p.Cabecera)
                .WithMany()
                .HasForeignKey(p => p.IdCabeceraDocumento)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.UnidadMedida)
                .WithMany()
                .HasForeignKey(p => p.IdUnidadMedida)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.TipoPrecio)
                .WithMany()
                .HasForeignKey(p => p.IdTipoPrecio)
                .WillCascadeOnDelete(false);

            Property(p => p.Cantidad)
                .HasPrecision(11, 2);

            Property(p => p.PrecioUnitario)
                .HasPrecision(11, 2);

            Property(p => p.Impuesto)
                .HasPrecision(11, 2);

            Property(p => p.ImpuestoSelectivo)
                .HasPrecision(11, 2);

            Property(p => p.OtroImpuesto)
                .HasPrecision(11, 2);

            Property(p => p.Descuento)
                .HasPrecision(11, 2);

            Property(p => p.TotalVenta)
                .HasPrecision(11, 2);

            Property(p => p.CodigoItem)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Descripcion)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}