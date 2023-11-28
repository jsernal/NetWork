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

            InicializarDatosAlInicio();

            Application.Run(new NetWork.Vista.FormIniciarSesionUsuario());

        }

        static void InicializarDatosAlInicio()
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
                PrecioBase = 85.30M
            };

            dbContext.TipoHabitacion.Add(tipoHabitacion1);

            var servicio1  = new Servicios
            {
                CodigoServicio = 1,
                Tipo = TipoServicio.Lavanderia,
                Precio = 8.50M
            };

            dbContext.Servicios.Add(servicio1);

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
}
