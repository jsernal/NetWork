using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWork.Modelo
{
    public class Reservas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoReservas {  get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida{ get; set; }
        public int IdCliente { get; set; }
        public int NumHabitacion { get; set; }
        public int EstadoReserva {  get; set; }
        [NotMapped]
        public Habitaciones Habitacion { get; set; }
        [NotMapped]
        public string EstadoReservaTexto
        {
            get
            {
                return EstadoReserva == 1 ? "Firmado" : "No Firmado";
            }
        }
        [NotMapped]
        public string NombreCliente { get; set; }
        [NotMapped]
        public int TelefonoCliente { get; set; }

        public Clientes Cliente { get; set; }

        public Reservas(int codigoReservas, DateTime fechaEntrada, DateTime fechaSalida, int idCliente, int numHabitacion, int estadoReserva, string nombreCliente)
        {
            CodigoReservas = codigoReservas;
            FechaEntrada = fechaEntrada;
            FechaSalida = fechaSalida;
            IdCliente = idCliente;
            NumHabitacion = numHabitacion;
            EstadoReserva = estadoReserva;
            NombreCliente = nombreCliente; 
        }
        public Reservas() { }

    }
}
