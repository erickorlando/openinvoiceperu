namespace OpenInvoicePeru.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorreoEmpresa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empresa", "CorreoElectronico", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Empresa", "CorreoElectronico");
        }
    }
}
