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
        public List<Reservas> ConsultarReservas(DateTime fechaSalida)
        {
            using (var context = new ConexionDB())
            {
                var fechaEntrada = DateTime.Today;

                var reservasConClientes = context.Reservas
                    .Include(r => r.Cliente)
                    .Where(r => r.FechaEntrada >= fechaEntrada && r.FechaSalida <= fechaSalida)
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
                    .Where(r => r.FechaEntrada <= fechaActual)
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
