namespace com.Yolia.App.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        ClienteRFC = c.String(),
                        Nombre = c.String(),
                        ApellidoPaterno = c.String(),
                        ApellidoMaterno = c.String(),
                        NumFijo = c.String(),
                        NumMovil = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Domicilio",
                c => new
                    {
                        DomicilioId = c.Int(nullable: false, identity: true),
                        Calle = c.String(),
                        NumInterior = c.String(),
                        NumExterior = c.String(),
                        Colonia = c.String(),
                        Estado = c.String(),
                        CodPostal = c.String(),
                    })
                .PrimaryKey(t => t.DomicilioId);
            
            CreateTable(
                "dbo.Servicio",
                c => new
                    {
                        FolioServicio = c.Int(nullable: false, identity: true),
                        FechaIniServicio = c.DateTime(nullable: false),
                        FechaFinServicio = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FolioServicio);
            
            CreateTable(
                "dbo.Pago",
                c => new
                    {
                        FolioPago = c.Int(nullable: false, identity: true),
                        ClavePago = c.String(),
                        MontoPago = c.String(),
                        FechaPago = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FolioPago);
            
            CreateTable(
                "dbo.DomicilioCliente",
                c => new
                    {
                        Domicilio_DomicilioId = c.Int(nullable: false),
                        Cliente_ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Domicilio_DomicilioId, t.Cliente_ClienteId })
                .ForeignKey("dbo.Domicilio", t => t.Domicilio_DomicilioId, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => t.Cliente_ClienteId, cascadeDelete: true)
                .Index(t => t.Domicilio_DomicilioId)
                .Index(t => t.Cliente_ClienteId);
            
            CreateTable(
                "dbo.ServicioCliente",
                c => new
                    {
                        Servicio_FolioServicio = c.Int(nullable: false),
                        Cliente_ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Servicio_FolioServicio, t.Cliente_ClienteId })
                .ForeignKey("dbo.Servicio", t => t.Servicio_FolioServicio, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => t.Cliente_ClienteId, cascadeDelete: true)
                .Index(t => t.Servicio_FolioServicio)
                .Index(t => t.Cliente_ClienteId);
            
            CreateTable(
                "dbo.PagoServicio",
                c => new
                    {
                        Pago_FolioPago = c.Int(nullable: false),
                        Servicio_FolioServicio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pago_FolioPago, t.Servicio_FolioServicio })
                .ForeignKey("dbo.Pago", t => t.Pago_FolioPago, cascadeDelete: true)
                .ForeignKey("dbo.Servicio", t => t.Servicio_FolioServicio, cascadeDelete: true)
                .Index(t => t.Pago_FolioPago)
                .Index(t => t.Servicio_FolioServicio);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PagoServicio", "Servicio_FolioServicio", "dbo.Servicio");
            DropForeignKey("dbo.PagoServicio", "Pago_FolioPago", "dbo.Pago");
            DropForeignKey("dbo.ServicioCliente", "Cliente_ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.ServicioCliente", "Servicio_FolioServicio", "dbo.Servicio");
            DropForeignKey("dbo.DomicilioCliente", "Cliente_ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.DomicilioCliente", "Domicilio_DomicilioId", "dbo.Domicilio");
            DropIndex("dbo.PagoServicio", new[] { "Servicio_FolioServicio" });
            DropIndex("dbo.PagoServicio", new[] { "Pago_FolioPago" });
            DropIndex("dbo.ServicioCliente", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.ServicioCliente", new[] { "Servicio_FolioServicio" });
            DropIndex("dbo.DomicilioCliente", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.DomicilioCliente", new[] { "Domicilio_DomicilioId" });
            DropTable("dbo.PagoServicio");
            DropTable("dbo.ServicioCliente");
            DropTable("dbo.DomicilioCliente");
            DropTable("dbo.Pago");
            DropTable("dbo.Servicio");
            DropTable("dbo.Domicilio");
            DropTable("dbo.Cliente");
        }
    }
}
