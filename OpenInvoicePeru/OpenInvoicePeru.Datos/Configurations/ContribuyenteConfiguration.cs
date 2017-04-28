using System.Data.Entity.ModelConfiguration;
using OpenInvoicePeru.Entidades;

namespace OpenInvoicePeru.Datos.Configurations
{
    public class ContribuyenteConfiguration : EntityTypeConfiguration<Contribuyente>
    {
        public ContribuyenteConfiguration()
        {
            const string prefix = "IX_Contribuyente_";

            Property(p => p.IdPais).HasIndex(prefix + "IdPais");
            Property(p => p.IdDepartamento).HasIndex(prefix + "IdDepartamento");
            Property(p => p.IdProvincia).HasIndex(prefix + "IdProvincia");
            Property(p => p.IdDistrito).HasIndex(prefix + "IdDistrito");
            Property(p => p.IdTipoDocumento).HasIndex(prefix + "IdTipoDocumento");

            HasRequired(p => p.Pais)
                .WithMany()
                .HasForeignKey(p => p.IdPais)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Departamento)
                .WithMany()
                .HasForeignKey(p => p.IdDepartamento)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Provincia)
                .WithMany()
                .HasForeignKey(p => p.IdProvincia)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Distrito)
                .WithMany()
                .HasForeignKey(p => p.IdDistrito)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.TipoDocumento)
                .WithMany()
                .HasForeignKey(p => p.IdTipoDocumento)
                .WillCascadeOnDelete(false);

            Property(p => p.NroDocumento)
                .HasMaxLength(11)
                .IsRequired();

            Property(p => p.NombreLegal)
                .HasMaxLength(200)
                .IsRequired();

            Property(p => p.NombreComercial)
                .HasMaxLength(200)
                .IsRequired();

            Property(p => p.Direccion)
                .HasMaxLength(500)
                .IsRequired();

            Property(p => p.Urbanizacion)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
