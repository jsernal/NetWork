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
        public DateTime Fecha { get; set; }
        public string DniCliente { get; set; }
        public int NumHabitacion { get; set; }

        public Reservas(int codigoReservas, DateTime fecha, string dniCliente, int numHabitacion)
        {
            CodigoReservas = codigoReservas;
            Fecha = fecha;
            DniCliente = dniCliente;
            NumHabitacion = numHabitacion;
        }
        public Reservas() { }
    }
}
