using System.Data.Entity.ModelConfiguration;
using OpenInvoicePeru.Entidades;

namespace OpenInvoicePeru.Datos.Configurations
{
    public class CabeceraDocumentoConfiguration : EntityTypeConfiguration<CabeceraDocumento>
    {
        public CabeceraDocumentoConfiguration()
        {
            Property(e => e.IdReceptor).HasIndex("IX_CabeceraDocumento_IdReceptor");

            Property(e => e.IdEmisor).HasIndex("IX_CabeceraDocumento_IdEmisor");

            Property(e => e.IdTipoDocumento).HasIndex("IX_CabeceraDocumento_IdTipoDocumento");

            Property(e => e.IdMoneda).HasIndex("IX_CabeceraDocumento_IdMoneda");

            Property(e => e.IdTipoOperacion).HasIndex("IX_CabeceraDocumento_IdTipoOperacion");

            Property(e => e.IdDocumentoAnticipo).HasIndex("IX_CabeceraDocumento_IdDocumentoAnticipo");

            Property(e => e.IdGuiaTransportista).HasIndex("IX_CabeceraDocumento_IdGuiaTransportista");
            
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
                .HasForeignKey(e => e.IdTipoDocumento);

            HasRequired(e => e.Moneda)
                .WithMany()
                .HasForeignKey(e => e.IdMoneda);

            HasRequired(e => e.TipoOperacion)
                .WithMany()
                .HasForeignKey(e => e.IdTipoOperacion);

            HasOptional(e => e.DocumentoAnticipo)
                .WithMany()
                .HasForeignKey(e => e.IdDocumentoAnticipo);

            HasOptional(e => e.GuiaTransportista)
                .WithMany()
                .HasForeignKey(e => e.IdGuiaTransportista);

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

        }
    }
}