namespace NetWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FechaFactura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "FechaFactura", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Facturas", "FechaFactura");
        }
    }
}
