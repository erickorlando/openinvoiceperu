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

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var initializer = new OpenInvoicePeruDbInitializer();
            Database.SetInitializer(initializer);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}