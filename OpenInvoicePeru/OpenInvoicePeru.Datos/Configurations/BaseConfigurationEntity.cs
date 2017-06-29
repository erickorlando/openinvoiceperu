using System.Data.Entity.ModelConfiguration;

namespace OpenInvoicePeru.Datos.Configurations
{
    public class BaseConfigurationEntity<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        protected readonly string Prefix;

        protected BaseConfigurationEntity()
        {
            Prefix = $"IX_{typeof(TEntity).Name}_";
        }
    }
}
