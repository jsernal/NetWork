namespace NetWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class facturaIDString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Facturas", "IdCliente", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Facturas", "IdCliente", c => c.Int(nullable: false));
        }
    }
}
