using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWork.Modelo
{
    public class TipoHabitacion
    {
        [Key]
        public int CodigoTipoHabit {  get; set; }
        public string Descripcion { get; set; }  
        public int Capacidad { get; set; }       
        public decimal PrecioBase { get; set; }

        public TipoHabitacion(string descripcion, int capacidad, decimal precioBase)
        {
            Descripcion = descripcion;
            Capacidad = capacidad;
            PrecioBase = precioBase;
        }
    }
}
