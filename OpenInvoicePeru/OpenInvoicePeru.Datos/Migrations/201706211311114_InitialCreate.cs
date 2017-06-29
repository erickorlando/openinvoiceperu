namespace OpenInvoicePeru.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CabeceraDocumento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTipoDocumento = c.Int(nullable: false),
                        IdEmisor = c.Int(nullable: false),
                        IdReceptor = c.Int(nullable: false),
                        IdMoneda = c.Int(nullable: false),
                        IdTipoOperacion = c.Int(nullable: false),
                        IdDocumentoAnticipo = c.Int(),
                        IdGuiaTransportista = c.Int(),
                        IdAnexo = c.Int(),
                        IdDocumento = c.String(nullable: false, maxLength: 13),
                        Gravadas = c.Decimal(nullable: false, precision: 11, scale: 2),
                        Gratuitas = c.Decimal(nullable: false, precision: 11, scale: 2),
                        Inafectas = c.Decimal(nullable: false, precision: 11, scale: 2),
                        Exoneradas = c.Decimal(nullable: false, precision: 11, scale: 2),
                        DescuentoGlobal = c.Decimal(nullable: false, precision: 11, scale: 2),
                        TotalVenta = c.Decimal(nullable: false, precision: 11, scale: 2),
                        TotalIgv = c.Decimal(nullable: false, precision: 11, scale: 2),
                        TotalIsc = c.Decimal(nullable: false, precision: 11, scale: 2),
                        TotalOtrosTributos = c.Decimal(nullable: false, precision: 11, scale: 2),
                        MontoEnLetras = c.String(nullable: false, maxLength: 250),
                        PlacaVehiculo = c.String(maxLength: 15),
                        MontoPercepcion = c.Decimal(nullable: false, precision: 11, scale: 2),
                        MontoDetraccion = c.Decimal(nullable: false, precision: 11, scale: 2),
                        EstadoDocumento = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Anexo", t => t.IdAnexo)
                .ForeignKey("dbo.DocumentoAnticipo", t => t.IdDocumentoAnticipo)
                .ForeignKey("dbo.Empresa", t => t.IdEmisor)
                .ForeignKey("dbo.GuiaTransportista", t => t.IdGuiaTransportista)
                .ForeignKey("dbo.Moneda", t => t.IdMoneda)
                .ForeignKey("dbo.Empresa", t => t.IdReceptor)
                .ForeignKey("dbo.TipoDocumentos", t => t.IdTipoDocumento)
                .ForeignKey("dbo.TipoOperaciones", t => t.IdTipoOperacion)
                .Index(t => t.IdTipoDocumento, name: "IX_CabeceraDocumento_IdTipoDocumento")
                .Index(t => t.IdEmisor, name: "IX_CabeceraDocumento_IdEmisor")
                .Index(t => t.IdReceptor, name: "IX_CabeceraDocumento_IdReceptor")
                .Index(t => t.IdMoneda, name: "IX_CabeceraDocumento_IdMoneda")
                .Index(t => t.IdTipoOperacion, name: "IX_CabeceraDocumento_IdTipoOperacion")
                .Index(t => t.IdDocumentoAnticipo, name: "IX_CabeceraDocumento_IdDocumentoAnticipo")
                .Index(t => t.IdGuiaTransportista, name: "IX_CabeceraDocumento_IdGuiaTransportista")
                .Index(t => t.IdAnexo, name: "IX_CabeceraDocumento_IdAnexo");
            
            CreateTable(
                "dbo.Anexo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaGeneracion = c.DateTime(nullable: false),
                        FechaRespuesta = c.DateTime(),
                        XmlFirmado = c.String(nullable: false),
                        RepresentacionImpresa = c.String(nullable: false),
                        EstadoEnvio = c.Short(nullable: false),
                        CodigoEstado = c.String(maxLength: 1),
                        DescripcionEstado = c.String(maxLength: 250),
                        CdrSunat = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DatoAdicional",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCabeceraDocumento = c.Int(nullable: false),
                        IdTipoDatoAdicional = c.Int(nullable: false),
                        Contenido = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CabeceraDocumento", t => t.IdCabeceraDocumento, cascadeDelete: true)
                .ForeignKey("dbo.TipoDatoAdicionales", t => t.IdTipoDatoAdicional, cascadeDelete: true)
                .Index(t => t.IdCabeceraDocumento)
                .Index(t => t.IdTipoDatoAdicional);
            
            CreateTable(
                "dbo.TipoDatoAdicionales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentoDetalle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCabeceraDocumento = c.Int(nullable: false),
                        Cantidad = c.Decimal(nullable: false, precision: 11, scale: 2),
                        IdUnidadMedida = c.Int(nullable: false),
                        CodigoItem = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 11, scale: 2),
                        IdTipoPrecio = c.Int(nullable: false),
                        Impuesto = c.Decimal(nullable: false, precision: 11, scale: 2),
                        ImpuestoSelectivo = c.Decimal(nullable: false, precision: 11, scale: 2),
                        OtroImpuesto = c.Decimal(nullable: false, precision: 11, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 11, scale: 2),
                        TotalVenta = c.Decimal(nullable: false, precision: 11, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoPrecio", t => t.IdTipoPrecio)
                .ForeignKey("dbo.UnidadMedida", t => t.IdUnidadMedida)
                .ForeignKey("dbo.CabeceraDocumento", t => t.IdCabeceraDocumento)
                .Index(t => t.IdCabeceraDocumento, name: "IX_DocumentoDetalle_IdCabeceraDocumento")
                .Index(t => t.IdUnidadMedida, name: "IX_DocumentoDetalle_IdUnidadMedida")
                .Index(t => t.IdTipoPrecio, name: "IX_DocumentoDetalle_IdTipoPrecio");
            
            CreateTable(
                "dbo.TipoPrecio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnidadMedida",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiscrepanciaDocumento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCabeceraDocumento = c.Int(nullable: false),
                        NroReferencia = c.String(nullable: false, maxLength: 15),
                        IdTipoDiscrepancia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CabeceraDocumento", t => t.IdCabeceraDocumento, cascadeDelete: true)
                .ForeignKey("dbo.TipoDiscrepancia", t => t.IdTipoDiscrepancia, cascadeDelete: true)
                .Index(t => t.IdCabeceraDocumento)
                .Index(t => t.IdTipoDiscrepancia);
            
            CreateTable(
                "dbo.TipoDiscrepancia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTipoDocumento = c.Int(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoDocumentos", t => t.IdTipoDocumento)
                .Index(t => t.IdTipoDocumento, name: "IX_TipoDiscrepancia_IdTipoDoc");
            
            CreateTable(
                "dbo.TipoDocumentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentoAnticipo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NroDocAnticipo = c.String(nullable: false),
                        IdTipoDocumento = c.Int(nullable: false),
                        IdMoneda = c.Int(nullable: false),
                        MontoAnticipo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Moneda", t => t.IdMoneda, cascadeDelete: true)
                .ForeignKey("dbo.TipoDocumentos", t => t.IdTipoDocumento, cascadeDelete: true)
                .Index(t => t.IdTipoDocumento)
                .Index(t => t.IdMoneda);
            
            CreateTable(
                "dbo.Moneda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentoRelacionado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCabeceraDocumento = c.Int(nullable: false),
                        NroDocumento = c.String(nullable: false, maxLength: 15),
                        TipoDocumento = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CabeceraDocumento", t => t.IdCabeceraDocumento, cascadeDelete: true)
                .Index(t => t.IdCabeceraDocumento);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NroDocumento = c.String(nullable: false, maxLength: 11),
                        IdTipoDocumento = c.Int(nullable: false),
                        NombreLegal = c.String(nullable: false, maxLength: 200),
                        NombreComercial = c.String(nullable: false, maxLength: 200),
                        Direccion = c.String(nullable: false, maxLength: 500),
                        Urbanizacion = c.String(nullable: false, maxLength: 50),
                        IdUbigeo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoDocumentoContribuyente", t => t.IdTipoDocumento)
                .ForeignKey("dbo.Ubigeo", t => t.IdUbigeo)
                .Index(t => t.IdTipoDocumento)
                .Index(t => t.IdUbigeo, name: "IX_Empresa_IdUbigeo");
            
            CreateTable(
                "dbo.TipoDocumentoContribuyente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ubigeo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 6),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuiaTransportista",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdModoTransporte = c.Int(nullable: false),
                        IdTipoDocTransportista = c.Int(nullable: false),
                        IdUnidadMedida = c.Int(nullable: false),
                        CodigoAutorizacion = c.String(nullable: false, maxLength: 10),
                        MarcaVehiculo = c.String(nullable: false, maxLength: 50),
                        NombreTransportista = c.String(nullable: false, maxLength: 100),
                        NroLicencia = c.String(nullable: false, maxLength: 10),
                        RucTransportista = c.String(nullable: false, maxLength: 11),
                        PesoBruto = c.Decimal(nullable: false, precision: 11, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModalidadTransporte", t => t.IdModoTransporte)
                .ForeignKey("dbo.TipoDocumentoContribuyente", t => t.IdTipoDocTransportista)
                .ForeignKey("dbo.UnidadMedida", t => t.IdUnidadMedida)
                .Index(t => t.IdModoTransporte, name: "IX_GuiaTransportista_IdModoTransporte")
                .Index(t => t.IdTipoDocTransportista, name: "IX_GuiaTransportista_IdTipoDocTransportista")
                .Index(t => t.IdUnidadMedida, name: "IX_GuiaTransportista_IdUnidadMedida");
            
            CreateTable(
                "dbo.ModalidadTransporte",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoOperaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DireccionesSunat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParametroConfiguracion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdContribuyente = c.Int(nullable: false),
                        TasaIgv = c.Decimal(nullable: false, precision: 11, scale: 2),
                        TasaIsc = c.Decimal(nullable: false, precision: 11, scale: 2),
                        TasaDetraccion = c.Decimal(nullable: false, precision: 11, scale: 2),
                        CertificadoDigital = c.String(nullable: false),
                        ClaveCertificado = c.String(nullable: false),
                        UsuarioSol = c.String(nullable: false, maxLength: 10),
                        ClaveSol = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.IdContribuyente)
                .Index(t => t.IdContribuyente, name: "IX_ParametroConfiguracion_IdContribuyente");
            
            CreateTable(
                "dbo.TipoDocumentoAnticipos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoDocumentoRelacionados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoImpuestos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParametroConfiguracion", "IdContribuyente", "dbo.Empresa");
            DropForeignKey("dbo.CabeceraDocumento", "IdTipoOperacion", "dbo.TipoOperaciones");
            DropForeignKey("dbo.CabeceraDocumento", "IdTipoDocumento", "dbo.TipoDocumentos");
            DropForeignKey("dbo.CabeceraDocumento", "IdReceptor", "dbo.Empresa");
            DropForeignKey("dbo.CabeceraDocumento", "IdMoneda", "dbo.Moneda");
            DropForeignKey("dbo.CabeceraDocumento", "IdGuiaTransportista", "dbo.GuiaTransportista");
            DropForeignKey("dbo.GuiaTransportista", "IdUnidadMedida", "dbo.UnidadMedida");
            DropForeignKey("dbo.GuiaTransportista", "IdTipoDocTransportista", "dbo.TipoDocumentoContribuyente");
            DropForeignKey("dbo.GuiaTransportista", "IdModoTransporte", "dbo.ModalidadTransporte");
            DropForeignKey("dbo.CabeceraDocumento", "IdEmisor", "dbo.Empresa");
            DropForeignKey("dbo.Empresa", "IdUbigeo", "dbo.Ubigeo");
            DropForeignKey("dbo.Empresa", "IdTipoDocumento", "dbo.TipoDocumentoContribuyente");
            DropForeignKey("dbo.DocumentoRelacionado", "IdCabeceraDocumento", "dbo.CabeceraDocumento");
            DropForeignKey("dbo.CabeceraDocumento", "IdDocumentoAnticipo", "dbo.DocumentoAnticipo");
            DropForeignKey("dbo.DocumentoAnticipo", "IdTipoDocumento", "dbo.TipoDocumentos");
            DropForeignKey("dbo.DocumentoAnticipo", "IdMoneda", "dbo.Moneda");
            DropForeignKey("dbo.DiscrepanciaDocumento", "IdTipoDiscrepancia", "dbo.TipoDiscrepancia");
            DropForeignKey("dbo.TipoDiscrepancia", "IdTipoDocumento", "dbo.TipoDocumentos");
            DropForeignKey("dbo.DiscrepanciaDocumento", "IdCabeceraDocumento", "dbo.CabeceraDocumento");
            DropForeignKey("dbo.DocumentoDetalle", "IdCabeceraDocumento", "dbo.CabeceraDocumento");
            DropForeignKey("dbo.DocumentoDetalle", "IdUnidadMedida", "dbo.UnidadMedida");
            DropForeignKey("dbo.DocumentoDetalle", "IdTipoPrecio", "dbo.TipoPrecio");
            DropForeignKey("dbo.DatoAdicional", "IdTipoDatoAdicional", "dbo.TipoDatoAdicionales");
            DropForeignKey("dbo.DatoAdicional", "IdCabeceraDocumento", "dbo.CabeceraDocumento");
            DropForeignKey("dbo.CabeceraDocumento", "IdAnexo", "dbo.Anexo");
            DropIndex("dbo.ParametroConfiguracion", "IX_ParametroConfiguracion_IdContribuyente");
            DropIndex("dbo.GuiaTransportista", "IX_GuiaTransportista_IdUnidadMedida");
            DropIndex("dbo.GuiaTransportista", "IX_GuiaTransportista_IdTipoDocTransportista");
            DropIndex("dbo.GuiaTransportista", "IX_GuiaTransportista_IdModoTransporte");
            DropIndex("dbo.Empresa", "IX_Empresa_IdUbigeo");
            DropIndex("dbo.Empresa", new[] { "IdTipoDocumento" });
            DropIndex("dbo.DocumentoRelacionado", new[] { "IdCabeceraDocumento" });
            DropIndex("dbo.DocumentoAnticipo", new[] { "IdMoneda" });
            DropIndex("dbo.DocumentoAnticipo", new[] { "IdTipoDocumento" });
            DropIndex("dbo.TipoDiscrepancia", "IX_TipoDiscrepancia_IdTipoDoc");
            DropIndex("dbo.DiscrepanciaDocumento", new[] { "IdTipoDiscrepancia" });
            DropIndex("dbo.DiscrepanciaDocumento", new[] { "IdCabeceraDocumento" });
            DropIndex("dbo.DocumentoDetalle", "IX_DocumentoDetalle_IdTipoPrecio");
            DropIndex("dbo.DocumentoDetalle", "IX_DocumentoDetalle_IdUnidadMedida");
            DropIndex("dbo.DocumentoDetalle", "IX_DocumentoDetalle_IdCabeceraDocumento");
            DropIndex("dbo.DatoAdicional", new[] { "IdTipoDatoAdicional" });
            DropIndex("dbo.DatoAdicional", new[] { "IdCabeceraDocumento" });
            DropIndex("dbo.CabeceraDocumento", "IX_CabeceraDocumento_IdAnexo");
            DropIndex("dbo.CabeceraDocumento", "IX_CabeceraDocumento_IdGuiaTransportista");
            DropIndex("dbo.CabeceraDocumento", "IX_CabeceraDocumento_IdDocumentoAnticipo");
            DropIndex("dbo.CabeceraDocumento", "IX_CabeceraDocumento_IdTipoOperacion");
            DropIndex("dbo.CabeceraDocumento", "IX_CabeceraDocumento_IdMoneda");
            DropIndex("dbo.CabeceraDocumento", "IX_CabeceraDocumento_IdReceptor");
            DropIndex("dbo.CabeceraDocumento", "IX_CabeceraDocumento_IdEmisor");
            DropIndex("dbo.CabeceraDocumento", "IX_CabeceraDocumento_IdTipoDocumento");
            DropTable("dbo.TipoImpuestos");
            DropTable("dbo.TipoDocumentoRelacionados");
            DropTable("dbo.TipoDocumentoAnticipos");
            DropTable("dbo.ParametroConfiguracion");
            DropTable("dbo.DireccionesSunat");
            DropTable("dbo.TipoOperaciones");
            DropTable("dbo.ModalidadTransporte");
            DropTable("dbo.GuiaTransportista");
            DropTable("dbo.Ubigeo");
            DropTable("dbo.TipoDocumentoContribuyente");
            DropTable("dbo.Empresa");
            DropTable("dbo.DocumentoRelacionado");
            DropTable("dbo.Moneda");
            DropTable("dbo.DocumentoAnticipo");
            DropTable("dbo.TipoDocumentos");
            DropTable("dbo.TipoDiscrepancia");
            DropTable("dbo.DiscrepanciaDocumento");
            DropTable("dbo.UnidadMedida");
            DropTable("dbo.TipoPrecio");
            DropTable("dbo.DocumentoDetalle");
            DropTable("dbo.TipoDatoAdicionales");
            DropTable("dbo.DatoAdicional");
            DropTable("dbo.Anexo");
            DropTable("dbo.CabeceraDocumento");
        }
    }
}
