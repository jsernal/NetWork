using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWork.Modelo
{
    public class ConexionDB : DbContext
    {
        public ConexionDB() : base("name=ConexionDB")
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Empleados> Empleados{ get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<Habitaciones> Habitaciones { get; set; }
        public DbSet<Recepcionista> Recepcionista { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<TipoAlojamiento> TipoAlojamiento { get; set; }
        public DbSet<TipoHabitacion> TipoHabitacion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleados>().ToTable("Empleados");
            modelBuilder.Entity<Administrador>().ToTable("Administradores");
            modelBuilder.Entity<Recepcionista>().ToTable("Recepcionistas");

            modelBuilder.Entity<Administrador>()
                .HasKey(e => e.CodigoEmpleado)
                .Property(e => e.CodigoEmpleado).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Recepcionista>()
                .HasKey(e => e.CodigoEmpleado)
                .Property(e => e.CodigoEmpleado).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }

    }
    
}
