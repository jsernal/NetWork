namespace NetWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioRegistrosReservas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservas", "FechaEntrada", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservas", "FechaSalida", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservas", "Fecha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservas", "Fecha", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservas", "FechaSalida");
            DropColumn("dbo.Reservas", "FechaEntrada");
        }
    }
}
