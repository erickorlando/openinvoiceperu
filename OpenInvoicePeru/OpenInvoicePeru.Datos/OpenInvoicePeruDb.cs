using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using OpenInvoicePeru.Entidades;

namespace OpenInvoicePeru.Datos
{
    using System.Data.Entity;

    public class OpenInvoicePeruDb : DbContext
    {
        // Your context has been configured to use a 'OpenInvoicePeruDb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'OpenInvoicePeru.Datos.OpenInvoicePeruDb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'OpenInvoicePeruDb' 
        // connection string in the application configuration file.
        public OpenInvoicePeruDb()
            : base("OpenInvoicePeruDb")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<TipoDocumentoContribuyente> TipoDocumentoContribuyentes { get; set; }
        public virtual DbSet<TipoOperacion> TipoOperaciones { get; set; }
        public virtual DbSet<TipoImpuesto> TipoImpuestos { get; set; }
        public virtual DbSet<TipoPrecio> TipoPrecios { get; set; }
        public virtual DbSet<TipoDocumentoRelacionado> TipoDocumentoRelacionados { get; set; }
        public virtual DbSet<TipoDocumentoAnticipo> TipoDocumentoAnticipos { get; set; }
        public virtual DbSet<TipoDiscrepancia> TipoDiscrepancias { get; set; }
        public virtual DbSet<TipoDatoAdicional> TipoDatoAdicionales { get; set; }
        public virtual DbSet<Moneda> Monedas { get; set; }
        public virtual DbSet<ModalidadTransporte> ModalidadTransportes { get; set; }
        public virtual DbSet<DireccionSunat> DireccionesSunat { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<DatoAdicional> DatosAdicionales { get; set; }
        public virtual DbSet<CabeceraDocumento> CabeceraDocumentos { get; set; }
        public virtual DbSet<DocumentoDetalle> DetalleDocumentos { get; set; }
        public virtual DbSet<DiscrepanciaDocumento> Discrepancias { get; set; }
        public virtual DbSet<DocumentoAnticipo> DocumentoAnticipos { get; set; }
        public virtual DbSet<DocumentoRelacionado> DocumentoRelacionados { get; set; }
        public virtual DbSet<GuiaTransportista> GuiaTransportistas { get; set; }
        public virtual DbSet<Ubigeo> Ubigeos { get; set; }
        public virtual DbSet<UnidadMedida> UnidadMedidas { get; set; }
        public virtual DbSet<ParametroConfiguracion> Parametros { get; set; }
             
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            var initializer = new OpenInvoicePeruDbInitializer();
            Database.SetInitializer(initializer);
        }

        public virtual void SetEntityState(IEntity entity)
        {
            SetEntityState(entity, entity.Id == 0 ? EntityState.Added : EntityState.Modified);
        }

        public virtual void SetEntityState(object entity, EntityState newState)
        {
            Entry(entity).State = newState;
        }

    }

}