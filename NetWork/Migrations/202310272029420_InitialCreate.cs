namespace NetWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        CodigoEmpleado = c.Int(nullable: false),
                        Nombre = c.String(),
                        Dni = c.String(),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.CodigoEmpleado);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Dni = c.String(),
                        Nombre = c.String(),
                        Telefono = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        NumFactura = c.Int(nullable: false, identity: true),
                        IdCliente = c.Int(nullable: false),
                        CodigoServicio = c.Int(nullable: false),
                        TotalFactura = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.NumFactura);
            
            CreateTable(
                "dbo.Habitaciones",
                c => new
                    {
                        NumHabitacion = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                        Tipo_CodigoTipoHabit = c.Int(),
                    })
                .PrimaryKey(t => t.NumHabitacion)
                .ForeignKey("dbo.TipoHabitacions", t => t.Tipo_CodigoTipoHabit)
                .Index(t => t.Tipo_CodigoTipoHabit);
            
            CreateTable(
                "dbo.TipoHabitacions",
                c => new
                    {
                        CodigoTipoHabit = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Capacidad = c.Int(nullable: false),
                        PrecioBase = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CodigoTipoHabit);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        CodigoReservas = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        DniCliente = c.String(),
                        NumHabitacion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoReservas);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        CodigoServicio = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CodigoServicio);
            
            CreateTable(
                "dbo.TipoAlojamientoes",
                c => new
                    {
                        CodigoTipoAloj = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CodigoTipoAloj);
            
            CreateTable(
                "dbo.Administradores",
                c => new
                    {
                        CodigoEmpleado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoEmpleado)
                .ForeignKey("dbo.Empleados", t => t.CodigoEmpleado)
                .Index(t => t.CodigoEmpleado);
            
            CreateTable(
                "dbo.Recepcionistas",
                c => new
                    {
                        CodigoEmpleado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoEmpleado)
                .ForeignKey("dbo.Empleados", t => t.CodigoEmpleado)
                .Index(t => t.CodigoEmpleado);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recepcionistas", "CodigoEmpleado", "dbo.Empleados");
            DropForeignKey("dbo.Administradores", "CodigoEmpleado", "dbo.Empleados");
            DropForeignKey("dbo.Habitaciones", "Tipo_CodigoTipoHabit", "dbo.TipoHabitacions");
            DropIndex("dbo.Recepcionistas", new[] { "CodigoEmpleado" });
            DropIndex("dbo.Administradores", new[] { "CodigoEmpleado" });
            DropIndex("dbo.Habitaciones", new[] { "Tipo_CodigoTipoHabit" });
            DropTable("dbo.Recepcionistas");
            DropTable("dbo.Administradores");
            DropTable("dbo.TipoAlojamientoes");
            DropTable("dbo.Servicios");
            DropTable("dbo.Reservas");
            DropTable("dbo.TipoHabitacions");
            DropTable("dbo.Habitaciones");
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Empleados");
        }
    }
}
