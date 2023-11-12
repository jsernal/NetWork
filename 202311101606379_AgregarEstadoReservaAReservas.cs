namespace NetWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarEstadoReservaAReservas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservas", "EstadoReserva", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservas", "EstadoReserva");
        }
    }
}
