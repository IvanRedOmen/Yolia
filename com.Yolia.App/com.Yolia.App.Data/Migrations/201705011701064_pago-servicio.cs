namespace com.Yolia.App.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pagoservicio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PagoServicio", "Pago_FolioPago", "dbo.Pago");
            DropForeignKey("dbo.PagoServicio", "Servicio_FolioServicio", "dbo.Servicio");
            DropIndex("dbo.PagoServicio", new[] { "Pago_FolioPago" });
            DropIndex("dbo.PagoServicio", new[] { "Servicio_FolioServicio" });
            DropPrimaryKey("dbo.Pago");
            AddColumn("dbo.Pago", "FolioServicio", c => c.Int(nullable: false));
            AlterColumn("dbo.Pago", "FolioPago", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Pago", "FolioPago");
            CreateIndex("dbo.Pago", "FolioPago");
            AddForeignKey("dbo.Pago", "FolioPago", "dbo.Servicio", "FolioServicio");
            DropTable("dbo.PagoServicio");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PagoServicio",
                c => new
                    {
                        Pago_FolioPago = c.Int(nullable: false),
                        Servicio_FolioServicio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pago_FolioPago, t.Servicio_FolioServicio });
            
            DropForeignKey("dbo.Pago", "FolioPago", "dbo.Servicio");
            DropIndex("dbo.Pago", new[] { "FolioPago" });
            DropPrimaryKey("dbo.Pago");
            AlterColumn("dbo.Pago", "FolioPago", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Pago", "FolioServicio");
            AddPrimaryKey("dbo.Pago", "FolioPago");
            CreateIndex("dbo.PagoServicio", "Servicio_FolioServicio");
            CreateIndex("dbo.PagoServicio", "Pago_FolioPago");
            AddForeignKey("dbo.PagoServicio", "Servicio_FolioServicio", "dbo.Servicio", "FolioServicio", cascadeDelete: true);
            AddForeignKey("dbo.PagoServicio", "Pago_FolioPago", "dbo.Pago", "FolioPago", cascadeDelete: true);
        }
    }
}
