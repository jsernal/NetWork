namespace NetWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarTablasAdminYRecep : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Empleados", newName: "Administradores");
            DropPrimaryKey("dbo.Administradores");
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
                "dbo.Recepcionistas",
                c => new
                    {
                        CodigoEmpleado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoEmpleado)
                .ForeignKey("dbo.Empleados", t => t.CodigoEmpleado)
                .Index(t => t.CodigoEmpleado);
            
            AlterColumn("dbo.Administradores", "CodigoEmpleado", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Administradores", "CodigoEmpleado");
            CreateIndex("dbo.Administradores", "CodigoEmpleado");
            AddForeignKey("dbo.Administradores", "CodigoEmpleado", "dbo.Empleados", "CodigoEmpleado");
            DropColumn("dbo.Administradores", "Nombre");
            DropColumn("dbo.Administradores", "Dni");
            DropColumn("dbo.Administradores", "Telefono");
            DropColumn("dbo.Administradores", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Administradores", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Administradores", "Telefono", c => c.String());
            AddColumn("dbo.Administradores", "Dni", c => c.String());
            AddColumn("dbo.Administradores", "Nombre", c => c.String());
            DropForeignKey("dbo.Recepcionistas", "CodigoEmpleado", "dbo.Empleados");
            DropForeignKey("dbo.Administradores", "CodigoEmpleado", "dbo.Empleados");
            DropIndex("dbo.Recepcionistas", new[] { "CodigoEmpleado" });
            DropIndex("dbo.Administradores", new[] { "CodigoEmpleado" });
            DropPrimaryKey("dbo.Administradores");
            AlterColumn("dbo.Administradores", "CodigoEmpleado", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Recepcionistas");
            DropTable("dbo.Empleados");
            AddPrimaryKey("dbo.Administradores", "CodigoEmpleado");
            RenameTable(name: "dbo.Administradores", newName: "Empleados");
        }
    }
}
