using OpenInvoicePeru.Entidades;

namespace OpenInvoicePeru.Datos.Configurations
{
    public class CabeceraDocumentoConfiguration : BaseConfigurationEntity<CabeceraDocumento>
    {
        public CabeceraDocumentoConfiguration()
        {
            Property(e => e.IdReceptor).HasIndex(Prefix + "IdReceptor");

            Property(e => e.IdEmisor).HasIndex(Prefix + "IdEmisor");

            Property(e => e.IdTipoDocumento).HasIndex(Prefix + "IdTipoDocumento");

            Property(e => e.IdMoneda).HasIndex(Prefix + "IdMoneda");

            Property(e => e.IdTipoOperacion).HasIndex(Prefix + "IdTipoOperacion");

            Property(e => e.IdDocumentoAnticipo).HasIndex(Prefix + "IdDocumentoAnticipo");

            Property(e => e.IdGuiaTransportista).HasIndex(Prefix + "IdGuiaTransportista");

            Property(e => e.IdAnexo).HasIndex(Prefix + "IdAnexo");

            HasRequired(e => e.Emisor)
                .WithMany()
                .HasForeignKey(e => e.IdEmisor)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.Receptor)
                .WithMany()
                .HasForeignKey(e => e.IdReceptor)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.TipoDocumento)
                .WithMany()
                .HasForeignKey(e => e.IdTipoDocumento)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.Moneda)
                .WithMany()
                .HasForeignKey(e => e.IdMoneda)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.TipoOperacion)
                .WithMany()
                .HasForeignKey(e => e.IdTipoOperacion)
                .WillCascadeOnDelete(false);

            HasOptional(p => p.GuiaTransportista)
                .WithMany()
                .HasForeignKey(p => p.IdGuiaTransportista)
                .WillCascadeOnDelete(false);

            HasOptional(e => e.DocumentoAnticipo)
                .WithMany()
                .HasForeignKey(e => e.IdDocumentoAnticipo)
                .WillCascadeOnDelete(false);

            HasOptional(e => e.Anexo)
                .WithMany()
                .HasForeignKey(e => e.IdAnexo)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Detalles)
                .WithRequired(e => e.Cabecera)
                .HasForeignKey(e => e.IdCabeceraDocumento)
                .WillCascadeOnDelete(false);

            Property(e => e.TotalIsc)
                .HasPrecision(11, 2);

            Property(e => e.TotalIgv)
                .HasPrecision(11, 2);

            Property(e => e.TotalOtrosTributos)
                .HasPrecision(11, 2);

            Property(e => e.TotalVenta)
                .HasPrecision(11, 2);

            Property(e => e.Gravadas)
                .HasPrecision(11, 2);

            Property(e => e.Gratuitas)
                .HasPrecision(11, 2);

            Property(e => e.Exoneradas)
                .HasPrecision(11, 2);

            Property(e => e.Inafectas)
                .HasPrecision(11, 2);

            Property(e => e.MontoDetraccion)
                .HasPrecision(11, 2);

            Property(e => e.MontoPercepcion)
                .HasPrecision(11, 2);

            Property(e => e.DescuentoGlobal)
                .HasPrecision(11, 2);

            Property(p => p.IdDocumento)
                .HasMaxLength(13)
                .IsRequired();

            Property(p => p.MontoEnLetras)
                .HasMaxLength(250)
                .IsRequired();

            Property(p => p.PlacaVehiculo)
                .HasMaxLength(15)
                .IsOptional();

            Property(p => p.EstadoDocumento)
                .HasMaxLength(2)
                .IsOptional();
        }
    }
}