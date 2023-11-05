using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWork.Modelo {
    public class Habitaciones
    {
        [Key]
        public int NumHabitacion {  get; set; }
        public string Estado { get; set; }
        public TipoHabitacion Tipo { get; set; }

        public Habitaciones(int numHabitacion, string estado, TipoHabitacion tipo)
        {
            NumHabitacion = numHabitacion;
            Estado = estado;
            Tipo = tipo;
        }

        public Habitaciones()
        {
        }
    }
}
