namespace NetWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevaMigracion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservas", "FechaEntrada", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservas", "FechaSalida", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservas", "IdCliente", c => c.Int(nullable: false));
            AddColumn("dbo.Reservas", "EstadoReserva", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservas", "IdCliente");
            AddForeignKey("dbo.Reservas", "IdCliente", "dbo.Clientes", "IdCliente", cascadeDelete: true);
            DropColumn("dbo.Reservas", "Fecha");
            DropColumn("dbo.Reservas", "DniCliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservas", "DniCliente", c => c.String());
            AddColumn("dbo.Reservas", "Fecha", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Reservas", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Reservas", new[] { "IdCliente" });
            DropColumn("dbo.Reservas", "EstadoReserva");
            DropColumn("dbo.Reservas", "IdCliente");
            DropColumn("dbo.Reservas", "FechaSalida");
            DropColumn("dbo.Reservas", "FechaEntrada");
        }
    }
}
