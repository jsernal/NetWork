namespace NetWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioIdClienteReservas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservas", "IdCliente", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservas", "IdCliente");
            AddForeignKey("dbo.Reservas", "IdCliente", "dbo.Clientes", "IdCliente", cascadeDelete: true);
            DropColumn("dbo.Reservas", "DniCliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservas", "DniCliente", c => c.String());
            DropForeignKey("dbo.Reservas", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Reservas", new[] { "IdCliente" });
            DropColumn("dbo.Reservas", "IdCliente");
        }
    }
}
