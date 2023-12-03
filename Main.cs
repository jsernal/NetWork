using NetWork.Modelo;
using System;
using System.Linq;
using System.Windows.Forms;

namespace NetWork
{
    public static class Mian
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           // InicializarDatosAlInicio();

            Application.Run(new NetWork.Vista.FormIniciarSesionUsuario());

        }
    }
}

     /*   static void InicializarDatosAlInicio()
        {
            using (var dbContext = new ConexionDB())
            {

                if (!dbContext.Clientes.Any())
                {
                    InicializarDatos(dbContext);

                    Console.WriteLine("Datos inicializados correctamente.");
                }
            }
        }


        static void InicializarDatos(ConexionDB dbContext)
        {

            var tipoHabitacion1 = new TipoHabitacion
            {
                CodigoTipoHabit = 1,
                Descripcion = "Habitación Estándar",
                Capacidad = 16,
                PrecioBase = 55.30M
            };

            dbContext.TipoHabitacion.Add(tipoHabitacion1);

            var tipoHabitacion2 = new TipoHabitacion
            {
                CodigoTipoHabit = 2,
                Descripcion = "Suite de Lujo",
                Capacidad = 26,
                PrecioBase = 185.30M
            };

            dbContext.TipoHabitacion.Add(tipoHabitacion2);

            var tipoHabitacion3 = new TipoHabitacion
            {
                CodigoTipoHabit = 3,
                Descripcion = "Habitación Familiar",
                Capacidad = 26,
                PrecioBase = 85.30M
            };

            dbContext.TipoHabitacion.Add(tipoHabitacion3);

            var tipoHabitacion4 = new TipoHabitacion
            {
                CodigoTipoHabit = 4,
                Descripcion = "Habitación Individual",
                Capacidad = 14,
                PrecioBase = 45.30M
            };

            dbContext.TipoHabitacion.Add(tipoHabitacion4);

            var tipoHabitacion5 = new TipoHabitacion
            {
                CodigoTipoHabit = 5,
                Descripcion = "Habitación Doble",
                Capacidad = 20,
                PrecioBase = 95.30M
            };

            dbContext.TipoHabitacion.Add(tipoHabitacion5);

            var servicio1  = new Servicios
            {
                CodigoServicio = 1,
                Tipo = TipoServicio.Restaurante,
                Precio = 28.50M
            };

            dbContext.Servicios.Add(servicio1);

            var servicio2 = new Servicios
            {
                CodigoServicio = 2,
                Tipo = TipoServicio.Lavanderia,
                Precio = 8.50M
            };
            dbContext.Servicios.Add(servicio2);


            var servicio3 = new Servicios
            {
                CodigoServicio = 3,
                Tipo = TipoServicio.Gimnasio,
                Precio = 10.50M
            };

            dbContext.Servicios.Add(servicio3);

            var tipoAloj1 = new TipoAlojamiento
            {
                CodigoTipoAloj = 1,
                Descripcion = "Pensión Completa",
                Precio = 42.18M
            };

            dbContext.TipoAlojamiento.Add(tipoAloj1);



            // Guarda los cambios en la base de datos
            dbContext.SaveChanges();
        }




    }
} */
