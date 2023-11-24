using NetWork.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetWork.Controlador
{
    public class RecepcionistaControlador
    {
        public static bool VerificarDisponibilidad(int numHabitacion, DateTime fechaEntrada, DateTime fechaSalida)
        {
            using (var context = new ConexionDB())
            {
                return !context.Reservas
                    .Any(r => r.NumHabitacion == numHabitacion &&
                              r.FechaEntrada < fechaSalida &&
                              r.FechaSalida > fechaEntrada);
            }
        }
        public List<HistorialCliente> ConsultarHistorial(int idCliente)
        {
            using (var context = new ConexionDB())
            {

                var historialClientes = context.Reservas
                .Include(r => r.Cliente)
                .Where(r => r.Cliente.IdCliente == idCliente)
                .Join(context.Habitaciones, 
                 reserva => reserva.NumHabitacion,
                habitacion => habitacion.NumHabitacion,
                (reserva, habitacion) => new { Reserva = reserva, Habitacion = habitacion })
                .Select(r => new HistorialCliente 
           {
               CodigoReservas = r.Reserva.CodigoReservas,
               FechaEntrada = r.Reserva.FechaEntrada,
               FechaSalida = r.Reserva.FechaSalida,
               NombreCliente = r.Reserva.Cliente.Nombre,
               NumHabitacion = r.Reserva.NumHabitacion,
               DescripcionTipoHabitacion = r.Habitacion.Tipo.Descripcion
           })
           .ToList();

                return historialClientes;
            }
        }
        public class HistorialCliente
        {
            public int CodigoReservas { get; set; }
            public DateTime FechaEntrada { get; set; }
            public DateTime FechaSalida { get; set; }
            public string NombreCliente { get; set; }
            public int NumHabitacion { get; set; }
            public string DescripcionTipoHabitacion { get; set; }
        }
        public List<Reservas> ConsultarReservas(DateTime fechaSalida)
        {
            using (var context = new ConexionDB())
            {
                var fechaEntrada = DateTime.Today;

                var reservasConClientes = context.Reservas
                    .Include(r => r.Cliente)
                    .Where(r => r.FechaEntrada <= fechaSalida && r.FechaSalida >= fechaEntrada)
                    .Select(r => new
                    {
                        CodigoReservas = r.CodigoReservas,
                        FechaEntrada = r.FechaEntrada,
                        FechaSalida = r.FechaSalida,
                        NombreCliente = r.Cliente.Nombre,
                        IdCliente = r.IdCliente, 
                        NumHabitacion = r.NumHabitacion,
                        EstadoReserva = r.EstadoReserva
                    })
                    .ToList();

                var reservasConClientesList = reservasConClientes
                    .Select(r => new Reservas
                    {
                        CodigoReservas = r.CodigoReservas,
                        FechaEntrada = r.FechaEntrada,
                        FechaSalida = r.FechaSalida,
                        NombreCliente = r.NombreCliente,
                        IdCliente = r.IdCliente, 
                        NumHabitacion = r.NumHabitacion,
                        EstadoReserva = r.EstadoReserva
                    })
                    .ToList();

                return reservasConClientesList;
            }
        }
        public bool FirmarReserva(int codigoReserva, out string mensajeError)
        {
            mensajeError = null; 

            using (var context = new ConexionDB())
            {
                try
                {
                    // Busca la reserva en la base de datos por el código
                    var reserva = context.Reservas.FirstOrDefault(r => r.CodigoReservas == codigoReserva);

                    if (reserva != null)
                    {
                        // Actualiza el estado de la reserva a "firmada" 
                        reserva.EstadoReserva = 1; 

                        
                        context.SaveChanges();

                        
                        return true;
                    }
                    else
                    {
                        mensajeError = "No se encontró una reserva con ese código.";
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    
                    mensajeError = $"Error al firmar reserva: {ex.Message}";
                    return false;
                }
            }
        }
        public List<Reservas> VerificarReservas()
        {
            using (var context = new ConexionDB())
            {
                var fechaActual = DateTime.Now;

                var reservasAtrasadas = context.Reservas
                    .Include(r => r.Cliente)
                    .Where(r => r.FechaEntrada <= fechaActual && r.EstadoReserva == 0)
                    .Select(r => new
                    {
                        CodigoReservas = r.CodigoReservas,
                        FechaEntrada = r.FechaEntrada,
                        NombreCliente = r.Cliente.Nombre,
                        TelefonoCliente = r.Cliente.Telefono,
                        
                    })
                    .ToList();

                var reservasList = new List<Reservas>(); 

                foreach (var reserva in reservasAtrasadas)
                {
                    var reservaObj = new Reservas
                    {
                        CodigoReservas = reserva.CodigoReservas,
                        FechaEntrada = reserva.FechaEntrada,
                        NombreCliente = reserva.NombreCliente,
                        TelefonoCliente = reserva.TelefonoCliente,
                       
                    };

                    reservasList.Add(reservaObj);
                }

                return reservasList;
            }
        }
    }
}
